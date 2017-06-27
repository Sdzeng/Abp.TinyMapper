using Abp.Modules;
using Abp.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration.Startup;
using Abp.Localization;
using Nelibur.ObjectMapper;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Abp.ObjectMapping;
using System.Linq.Expressions;
using System.ComponentModel;

namespace Abp.TinyMapper
{


    [DependsOn(typeof(AbpKernelModule))]
    public class AbpTinyMapperModule : AbpModule
    {
        private readonly ITypeFinder _typeFinder;
        private static readonly object SyncObj = new object();

        public AbpTinyMapperModule(ITypeFinder typeFinder)
        {
            //#if !NET46
            //            throw new Exception("Abp.TinyMapper暂时不支持.net standard");
            //#endif
            _typeFinder = typeFinder;
        }

        public override void PreInitialize()
        {

            IocManager.Register<IAbpTinyMapperConfiguration, AbpTinyMapperConfiguration>();

            Configuration.ReplaceService<IObjectMapper, TinyMapperObjectMapper>();

            //Configuration.Modules.AbpTinyMapper().Configurators.Add(CreateCoreMappings);
        }

        public override void PostInitialize()
        {
            CreateMappings();
        }

        private void CreateMappings()
        {
            lock (SyncObj)
            {

                Action<Nelibur.ObjectMapper.ITinyMapperConfig> configurer = configuration =>
                {
                    var abpTinyMapperConfiguration = Configuration.Modules.AbpTinyMapper();

                    if (null != abpTinyMapperConfiguration)
                    {
                        configuration.EnableAutoBinding = abpTinyMapperConfiguration.EnableAutoBinding;
                        configuration.EnablePolymorphicMapping = abpTinyMapperConfiguration.EnablePolymorphicMapping;

                        if (null != abpTinyMapperConfiguration.NameMatching)
                        {
                            configuration.NameMatching(abpTinyMapperConfiguration.NameMatching);
                        }

                        if (abpTinyMapperConfiguration.IsReset)
                        {
                            configuration.Reset();
                        }
                    }

                    FindAndTinyMapTypes();

                    foreach (var configurator in abpTinyMapperConfiguration?.Configurators)
                    {
                        configurator();
                    }
                };

                Nelibur.ObjectMapper.TinyMapper.Config(configurer);
            }
        }


        //private void CreateMappings()
        //{
        //    lock (SyncObj)
        //    {
        //        FindAndTinyMapTypes();
        //        var abpTinyMapperConfiguration = Configuration.Modules.AbpTinyMapper();
        //        if (null != abpTinyMapperConfiguration)
        //        {
        //            foreach (var configurator in abpTinyMapperConfiguration.Configurators)
        //            {
        //                configurator();
        //            }
        //        }
        //    }
        //}

        private void FindAndTinyMapTypes()
        {
            CreateCoreMappings();

               var types = _typeFinder.Find(type =>
            {
                var typeInfo = type.GetTypeInfo();
                return typeInfo.IsDefined(typeof(TinyMapAttribute)) ||
                       typeInfo.IsDefined(typeof(TinyMapFromAttribute)) ||
                       typeInfo.IsDefined(typeof(TinyMapToAttribute));
            }
            );

            Logger.DebugFormat("Found {0} classes define tiny mapping attributes", types.Length);

            foreach (var type in types)
            {
                Logger.Debug(type.FullName);
                type.CreateTinyAttributeMaps();
            }
        }






        private void CreateCoreMappings()
        {
            var localizationContext = IocManager.Resolve<ILocalizationContext>();

            Nelibur.ObjectMapper.TinyMapper.Bind<ILocalizableString, string>(config =>
            {
                config.BindObjectCustom(x =>
                {
                    if (null == x)
                    { return null; }
                    else
                    { return x.Localize(localizationContext); }
                });
            });

            Nelibur.ObjectMapper.TinyMapper.Bind<LocalizableString, string>(config =>
            {
                config.BindObjectCustom(x =>
                {
                    if (null == x)
                    { return null; }
                    else
                    { return localizationContext.LocalizationManager.GetString(x); }
                });
            });


            //TypeDescriptor.AddProviderTransparent();

        }



    }


}
