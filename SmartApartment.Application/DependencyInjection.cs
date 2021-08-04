using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SmartApartment.Application
{
    /*
     * This is another variant that i have noticed in many huge solutions. Let’s say you have around 100 interfaces and 100 implementations. 
     * Do you add all this 100 lines of code to the Startup.cs to register them in the container? That would be insane in the maintainability point of view. 
     * To keep things clean, what we can do is, Create a DependencyInjection static Class for every layer of the solution and only add the corresponding . required services to the corresponding Class.
     */
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // return services;
        }
    }
}
