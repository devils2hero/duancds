using EG.Graphql.CustomLib.Types;
using EG.Graphql.StoreQuerys.Childev;

namespace EG.Graphql.StoreQuerys
{
    public class StoreQuery : ObjectGraphTypeCustom
    {
        public StoreQuery(CourseStoreQuery _CourseStoreQuery)
        {
            this.AddField(_CourseStoreQuery.Fields);
        }
    }
}
