using System.Collections.Generic;

namespace EG.Model.CustomModels.Core
{
    public class PagedListModel<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int TotalPage { get; set; }

        public int TotalItem { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
    }
}
