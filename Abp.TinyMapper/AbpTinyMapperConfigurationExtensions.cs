using Abp.Configuration.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.TinyMapper
{
    /// <summary>
    /// Defines extension methods to <see cref="IModuleConfigurations"/> to allow to configure Abp.AutoMapper module.
    /// </summary>
    public static class AbpTinyMapperConfigurationExtensions
    {
        /// <summary>
        /// Used to configure Abp.AutoMapper module.
        /// </summary>
        public static IAbpTinyMapperConfiguration AbpTinyMapper(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAbpTinyMapperConfiguration>();
        }
    }
}
