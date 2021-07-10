using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inyeccion
{
    public class AutoServiceCallerImp : AutoServiceCaller
    {
        //inyeccion de dependencias por constructor
        private readonly AutoService BMWAutoService;
        private readonly AutoService FordAutoService;
        private readonly AutoService HondaAutoService;

        public AutoServiceCallerImp(AutoService BMWAutoService, AutoService FordAutoService, AutoService HondaAutoService)
        {
            this.BMWAutoService = BMWAutoService;
            this.FordAutoService = FordAutoService;
            this.HondaAutoService = HondaAutoService;
        }

        public void callAutoService()
        {
            BMWAutoService.getService();

            FordAutoService.getService();

            HondaAutoService.getService();
        }
    }
}
