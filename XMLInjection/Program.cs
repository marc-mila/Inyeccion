using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLInjection
{
    class Program
    {
        public static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            ConfigureContainer();
            Resolution();

            Console.ReadLine();
        }

        private static void Resolution()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var bmw = scope.Resolve<BMWAutoService>();
                var ford = scope.Resolve<FordAutoService>();
                var honda = scope.Resolve<HondaAutoService>();

                AutoServiceCallerImp autoServiceCallerImp = new AutoServiceCallerImp(bmw, ford, honda);
                autoServiceCallerImp.callAutoService();
             
            }
        }

        private static void ConfigureContainer()
        {
            var config = new ConfigurationBuilder();

            config.AddXmlFile("Autofac.xml");

            var module = new ConfigurationModule(config.Build());

            var builder = new ContainerBuilder();

            builder.RegisterModule(module);

            Container = builder.Build();

        }
    }
}
