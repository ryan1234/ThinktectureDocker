using Microsoft.AspNet.Builder;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Runtime;
using Thinktecture.IdentityServer.Core.Configuration;
using System.Security.Cryptography.X509Certificates;
using AspNet5Host.Configuration;

namespace IdentityServer3
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection();
        }

        public void Configure(IApplicationBuilder app, IApplicationEnvironment env)
        {
            var certFile = env.ApplicationBasePath + "/cert.pfx";

            app.UseRuntimeInfoPage();
            app.UseErrorPage();

            app.Map("/core", core =>
            {
                var factory = InMemoryFactory.Create(
                                users: Users.Get(),
                                clients: Clients.Get(),
                                scopes: Scopes.Get());

                var idsrvOptions = new IdentityServerOptions
                {
                    Factory = factory,
                    RequireSsl = false,
                    SigningCertificate = new X509Certificate2(certFile, "test")
                };

                core.UseIdentityServer(idsrvOptions);
            });            
        }
    }
}
