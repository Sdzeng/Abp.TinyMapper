
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.TinyMapper
{
    public class AbpTinyMapperConfiguration:IAbpTinyMapperConfiguration
    {
        public List<Action> Configurators { get; } = new List<Action>();
        public bool EnablePolymorphicMapping { get; set; } = true;
        public bool EnableAutoBinding { get; set; } = true;
        public Func<string, string, bool> NameMatching { get; set; } = null;
        public bool IsReset { get; set; } = false;
    }
}
