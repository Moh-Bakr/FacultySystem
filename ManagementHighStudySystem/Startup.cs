using ManagementHighStudySystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagementHighStudySystem.Startup))]
namespace ManagementHighStudySystem
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRole();
            addAdmin();
        }
        public void addAdmin()
        {
            var userAdmin = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.UserName = "admin";
            user.Email = "admin@cit.com";
            user.SSN = "123456";
            var check = userAdmin.Create(user, "Admin@1234");
            if (check.Succeeded)
            {
                userAdmin.AddToRole(user.Id, "admin");
            }
        }
        public void createRole()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (roleManager.RoleExists("admin"))
            {
                role = new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);
            }
            if (roleManager.RoleExists("user"))
            {
                role = new IdentityRole();
                role.Name = "user";
                roleManager.Create(role);
            }
            if (roleManager.RoleExists("student"))
            {
                role = new IdentityRole();
                role.Name = "student";
                roleManager.Create(role);
            }
        }
    }
}
