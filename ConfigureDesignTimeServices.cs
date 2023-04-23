using Microsoft.EntityFrameworkCore.Design;

namespace robot_controller_api
{
    public class ConfigureDesignTimeServices : IDesignTimeServices
    {
        void IDesignTimeServices.ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddHandlebarsScaffolding();
        }
    }
}
