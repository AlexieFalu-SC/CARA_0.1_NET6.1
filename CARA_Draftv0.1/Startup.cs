using CARA_Draftv0._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CARA_Draftv0._1.Startup))]
namespace CARA_Draftv0._1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            CreateUsersAndRoles();
        }

        public void CreateUsersAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("SuperAdmin"))
            {

                var role = new IdentityRole("SuperAdmin");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin@assmca.pr.gov";
                user.Email = "admin@assmca.pr.gov";
                user.NB_Primero = "Super";
                user.NB_Segundo = "Admin";
                user.AP_Primero = "Cara";
                user.AP_Segundo = "Assmca";
                user.Tel_Celular = "7875555555";
                user.Tel_Trabajo = "7875555555";
                user.PasswordChanged = true;
                user.Active = true;
                user.EmailConfirmed = true;
                string pwd = "Admin@2020";
                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "SuperAdmin");
                }
            }
            if (!roleManager.RoleExists("Registrado"))
            {
                var role = new IdentityRole("Registrado");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "registrado@assmca.pr.gov";
                user.Email = "registrado@assmca.pr.gov";
                user.NB_Primero = "Registrado";
                user.NB_Segundo = "De";
                user.AP_Primero = "Prueba";
                user.AP_Segundo = "Cara";
                user.Tel_Celular = "7875555555";
                user.Tel_Trabajo = "7875555555";
                user.PasswordChanged = true;
                user.Active = true;
                user.EmailConfirmed = true;
                string pwd = "Registrado@2020";
                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Registrado");
                }
            }
            if (!roleManager.RoleExists("Operador de Registro"))
            {
                var role = new IdentityRole("Operador de Registro");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Operador Estadistico"))
            {
                var role = new IdentityRole("Operador Estadistico");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("AdminCARA"))
            {
                var role = new IdentityRole("AdminCARA");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("AdminPlanificacion"))
            {
                var role = new IdentityRole("AdminPlanificacion");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("AdminObservatorio"))
            {
                var role = new IdentityRole("AdminObservatorio");
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("AdminTablero"))
            {
                var role = new IdentityRole("AdminTablero");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "tablero@assmca.pr.gov";
                user.Email = "tablero@assmca.pr.gov";
                user.NB_Primero = "Tablero";
                user.NB_Segundo = "De";
                user.AP_Primero = "Prueba";
                user.AP_Segundo = "Cara";
                user.Tel_Celular = "7875555555";
                user.Tel_Trabajo = "7875555555";
                user.PasswordChanged = true;
                user.Active = true;
                user.EmailConfirmed = true;
                string pwd = "Tablero@2020";
                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "AdminTablero");
                }
            }

        }
    }
}
