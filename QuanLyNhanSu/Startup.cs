using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
[assembly: OwinStartupAttribute(typeof(QuanLyNhanSu.Startup))]
namespace QuanLyNhanSu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Cấu hình SignalR
            app.MapSignalR();
        }
    }
}
