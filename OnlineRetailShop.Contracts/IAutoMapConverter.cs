using System.Collections.Generic;

namespace OnlineRetailShop.Api.Contracts
{
    public interface IAutoMapConverter<TSourceObj, TDestinationObj>
          where TSourceObj : class
          where TDestinationObj : class
    {
        TDestinationObj ConvertObject(TSourceObj srcObj);
        List<TDestinationObj> ConvertObjectCollection(IEnumerable<TSourceObj> srcObj);
    }
}
