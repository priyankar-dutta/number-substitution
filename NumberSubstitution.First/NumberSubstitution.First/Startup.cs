using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NumberSubstitution.First.BusinessLogic;
using NumberSubstitution.First.CoreLogic;
using NumberSubstitution.First.Settings;

namespace NumberSubstitution.First
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
            services.AddSingleton<IConfiguration>(configuration);
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            services.AddSingleton<INumberSubstitutionService, NumberSubstitutionService>();
            services.AddScoped<IDerivationService, DerivationService>();
        }
    }
}
