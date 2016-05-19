using Core.Interfaces;
using Core.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IoC
{
    public class DependencyRegistration: Ninject.Modules.NinjectModule
    {
            public override void Load()
            {
                Ninject.IKernel kernal = new StandardKernel();  
                Bind<IRoverService>().To<RoverService>();
                Bind<IPositionService>().To<PositionService>();
            }

    }
}
