using EG.Model.CustomModels.Core;
using EG.Model.Models.Childev;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Graphql.ModelsType.Childev
{
    public class CourseType  : ObjectGraphType<Course>
    {
        public CourseType()
        {
            Field(x => x._id);
            Field(x => x.CourseName);
            Field(x => x.CreatedDate);
            Field(x => x.Description);
            Field(x => x.ImagePath);
            Field(x => x.Background);
            Field(x => x.Price);
            Field(x => x.IsActive);
        }
    }
    public class CoursePagedType : ObjectGraphType<PagedListModel<Course>>
    {
        public CoursePagedType()
        {
            Field<ListGraphType<CourseType>>(
                "data",
                resolve: context => context.Source.Data
                );

            Field(x => x.PageIndex);
            Field(x => x.PageSize);
            Field(x => x.TotalItem);
            Field(x => x.TotalPage);
        }
    }
}
