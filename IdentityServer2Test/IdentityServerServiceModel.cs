using System.Reflection;
using Abp.EntityFrameworkCore;
using Abp.IdentityServer4;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TestProject;

namespace IdentityServer2Test
{
    [DependsOn(typeof(TestProjectWebCoreModule))]
    public class IdentityServerServiceModel : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityServerServiceModel).GetAssembly());
        }
    }
}
