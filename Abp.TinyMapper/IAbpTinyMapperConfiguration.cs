using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Abp.TinyMapper
{
    public interface IAbpTinyMapperConfiguration
    {
        List<Action> Configurators { get; }


        bool EnablePolymorphicMapping { get; set; }

        /// <summary>
        ///     Create an automatic binding based on property names
        /// </summary>
        bool EnableAutoBinding { get; set; }

        /// <summary>
        ///     Custom name matching function used for auto bindings
        /// </summary>
        /// <param name="nameMatching">Function to match names</param>
        Func<string, string, bool> NameMatching { get; set; }

        /// <summary>
        ///     Reset settings to default
        /// </summary>
        bool IsReset { get; set; }
    }
}
