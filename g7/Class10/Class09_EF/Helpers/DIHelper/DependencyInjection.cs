using Class09_EF.Repositories.Implementations;
using Class09_EF.Repositories.Interfaces;
using Class09_EF.Services.Implementations;
using Class09_EF.Services.Interfaces;

namespace Class09_EF.Helpers.DIHelper
{
    public static class DependencyInjection
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            //here we will add more and more repositories for all the models that we have in the future
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            //here we will add more and more services for all the models that we have in the future
        }
    }
}
