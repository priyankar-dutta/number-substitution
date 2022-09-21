using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NumberSubstitution.Third.BusinessLogic;
using NumberSubstitution.Third.CoreLogic;
using NumberSubstitution.Third.Settings;

namespace NumberSubstitution.Third
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
