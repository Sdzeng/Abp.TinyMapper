using IObjectMapper = Abp.ObjectMapping.IObjectMapper;


namespace Abp.TinyMapper
{
    public class TinyMapperObjectMapper : IObjectMapper
    {

        public TDestination Map<TDestination>(object source)
        {
            return Nelibur.ObjectMapper.TinyMapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Nelibur.ObjectMapper.TinyMapper.Map(source, destination);
        }
    }
}