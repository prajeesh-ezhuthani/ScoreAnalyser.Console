using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ScoreAnalyser.Services.Interface;

namespace ScoreAnalyser.Services.Autofac
{
    public class RegisterTypes
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<ScoreAnalyserService>().As<IScoreAnalyserService>().InstancePerLifetimeScope();
        }
    }
}
