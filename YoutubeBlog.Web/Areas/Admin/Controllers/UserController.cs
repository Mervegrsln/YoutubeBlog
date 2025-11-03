using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IToastNotification toast;
        private readonly IMapper mapper;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IToastNotification toast, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.toast = toast;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            // Bu kodda UserDto sınıfının var olduğunu varsayıyorum.
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                // Rol adlarını al ve Role özelliğine ata
                var role = string.Join("", await userManager.GetRolesAsync(findUser));
                item.Role = role;
            }
            return View(map);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(new UserAddDto { Roles = roles });
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);

            // Model geçerli ise (client-side ve server-side doğrulama geçtiyse)
            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email;

                // Kullanıcıyı oluşturmayı dene
                var result = await userManager.CreateAsync(map, userAddDto.Password);

                if (result.Succeeded)
                {
                    // Rolü bul ve kullanıcıya ata
                    var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());

                    // Rol adını kullanarak atama yapıyoruz (findRole.ToString() yerine findRole.Name)
                    await userManager.AddToRoleAsync(map, findRole.Name);

                    toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions() { Title = "İşlem başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    // Kullanıcı oluşturma başarısız olursa hataları ModelState'e ekle
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            // ModelState.IsValid false ise VEYA Identity işlemleri başarısız olursa:
            // CS0161 hatasını gidermek için son çare olarak View'ı geri döndürüyoruz.
            // Rol listesini yeniden yüklememiz gerekiyor ki View'da gözüksün.
            var roles = await roleManager.Roles.ToListAsync();
            userAddDto.Roles = roles;
            return View(userAddDto);
        }
    }
}