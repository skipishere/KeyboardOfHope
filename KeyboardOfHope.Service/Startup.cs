using System;
using System.Threading.Tasks;
using LightMeUp;
using Microsoft.Owin;
using Owin;

namespace KeyboardOfHope.Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var light = new Light();

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.Run(context =>
            {   
                switch (context.Request.Path.Value)
                {
                    case @"/pass":
                        Task.Run(async () => { await light.SolidGreen(); });
                        context.Response.StatusCode = 200;
                        break;

                    case @"/redalert":
                        light.PulseRed();
                        context.Response.StatusCode = 200;
                        break;

                    case @"/raw/blue":
                        light.SolidBlue();
                        context.Response.StatusCode = 200;
                        break;

                    default:
                        context.Response.ContentType = "text/plain";
                        return context.Response.WriteAsync($"Hi {context.Request.Path}");
                }

                return context.Response.WriteAsync(string.Empty);
            });
        }
    }
}
