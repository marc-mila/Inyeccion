using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InyeccionXML
{
    public class Program
    {
        public static IContainer Container { get; set; }
        public static void Main(string[] args)
        {
            ConfigureContainer();
            Resolucion();

            Console.ReadLine();
        }

        public static void ConfigureContainer()
        {

            var config = new ConfigurationBuilder();

            config.AddXmlFile("AutoFacConf.xml");

            var module = new ConfigurationModule(config.Build());

            var builder = new ContainerBuilder();

            builder.RegisterModule(module);

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
