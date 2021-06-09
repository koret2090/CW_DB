using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessComponent;
using BusinessLogicComponent;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Authorization
{
    public partial class AuthForm : Form
    {
        IConfiguration _config;
        public AuthForm()
        {
            _config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string login = loginTxtBox.Text.ToString();
            string pass = passLbl.Text.ToString();

            if (login == "")
            {
                MessageBox.Show("Не введен логин");
                return;
            }
            if (pass == "")
            {
                MessageBox.Show("Не введен пароль");
                return;
            }
            IUsersRepository rep = new UsersRepository(new Context(Connection.GetConnection(0, _config)));
            //Userinfo user = rep.FindUserByLogin(loginBox.Text);
            User user = rep.FindByName(login);
            if (user == null)
            {
                MessageBox.Show("Неверно введен логин или пароль");
            }
            else
            {
                OpenNewForm(Connection.GetConnection((int)user.Permissions, _config), user);
            }
        }
        private void guestLoginBtn_Click(object sender, EventArgs e)
        {
            IUsersRepository rep = new UsersRepository(new Context(Connection.GetConnection(0, _config)));
            User user = rep.FindByName("guest");            
            OpenNewForm(Connection.GetConnection((int)user.Permissions, _config), user);            
        }

        public void OpenNewForm(string connect, User user)
        {
            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {                   
                    if (user.Permissions == (int)Permission.User)
                    {
                       services.AddSingleton<UserForm>();
                       services.AddSingleton(provider => { return user; });

                       DependencyInjections.SetRepositoryDependencies(services);
                       DependencyInjections.SetControllersDependencies(services);
                       services.AddDbContext<Context>(option => option.UseNpgsql(connect));
                    }
                   else if (user.Permissions == (int)Permission.Admin)
                   {
                       services.AddSingleton<Admin>();                       

                       DependencyInjections.SetRepositoryDependencies(services);
                       DependencyInjections.SetControllersDependencies(services);
                       services.AddDbContext<Context>(option => option.UseNpgsql(connect));
                   }
                   else
                   {                       
                        services.AddSingleton<GuestForm>();

                        DependencyInjections.SetRepositoryDependencies(services);
                        DependencyInjections.SetControllersDependencies(services);
                        services.AddDbContext<Context>(option => option.UseNpgsql(connect));                       
                   }
               });
            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                
                MessageBox.Show("Login Successful!");
                this.Hide();
                if (user.Permissions == (int)Permission.User)
                {
                    var form = services.GetRequiredService<UserForm>();
                    form.Show();
                }
                else if (user.Permissions == (int)Permission.Admin)
                {
                    var form = services.GetRequiredService<Admin>();
                    form.Show();
                }
                else
                {
                    var form = services.GetRequiredService<GuestForm>();
                    form.Show();
                }
                

                Console.WriteLine("Successfully opened");
                                

            }
        }

        private void loginLbl_Click(object sender, EventArgs e)
        {

        }


        public static class DependencyInjections
        {
            public static void SetRepositoryDependencies(IServiceCollection services)
            {
                services.AddSingleton<IActorsRepository, ActorsRepository>();
                services.AddSingleton<IDirectorsRepository, DirectorsRepository>();
                services.AddSingleton<IFilmsRepository, FilmsRepository>();
                services.AddSingleton<IGenresRepository, GenresRepository>();
                services.AddSingleton<IStudiosRepository, StudiosRepository>();
                services.AddSingleton<IUsersRepository, UsersRepository>();
            }

            public static void SetControllersDependencies(IServiceCollection services)
            {
                services.AddScoped<GuestController>();
                services.AddScoped<UserController>();
                services.AddScoped<AdminController>();
            }
        }

    }
}
