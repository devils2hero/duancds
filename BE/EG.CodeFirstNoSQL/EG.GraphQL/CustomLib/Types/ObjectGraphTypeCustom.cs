using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.CustomLib.Types
{
    public class ObjectGraphTypeCustom : ObjectGraphType
    {
        public override FieldType AddField(FieldType fieldType)
        {
            return base.AddField(fieldType);
        }
        public void AddField(IEnumerable<FieldType> fieldTypes)
        {
            foreach (var fieldType in fieldTypes)
            {
                base.AddField(fieldType);
            }
        }
    }
}
