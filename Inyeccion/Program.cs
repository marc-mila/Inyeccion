using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inyeccion
{
    public class Program
    {
        public static IContainer Container  { get; set; }
        static void Main(string[] args)
        {
            ConfigureContainer();
            Resolucion();

            Console.ReadLine();
        }

        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BMWAutoService>().SingleInstance();
            builder.RegisterType<FordAutoService>().SingleInstance();
            builder.RegisterType<HondaAutoService>().SingleInstance();

            Container = builder.Build();
        }
        public static void Resolucion()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var bmw = scope.Resolve<BMWAutoService>();
                var ford = scope.Resolve<FordAutoService>();
                var honda = scope.Resolve<HondaAutoService>();

                AutoServiceCallerImp serviceCaller = new AutoServiceCallerImp(bmw, ford, honda);
                serviceCaller.callAutoService();
            }
        }
    }
}
