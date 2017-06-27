using Abp.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.TinyMapper
{
    // public class LocalizableStringConverter : TypeConverter
    //{
    //    private ILocalizationContext localizationContext = IocManager.Resolve<ILocalizationContext>();
    //    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    //    {
    //        return sourceType == typeof(ILocalizableString);
    //    }

    //    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    //    {
    //        var concreteValue = (ILocalizableString)value;
    //        var result = new TargetClass
    //        {
    //            FullName = string.Format("{0} {1}", concreteValue.FirstName, concreteValue.LastName)
    //        };
    //        return result;
    //    }
    //}

}
