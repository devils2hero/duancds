using EG.Model.CustomModels.Core;
using PagedList.Core;

namespace EG.Web.Core.Helpers
{
    public class PageModelCustom<T> where T : class
    {
        public static PagedListModel<T> GetPage(IPagedList<T> list, int currentPage, int itemPerPage)
        {
            var PagedList = new PagedListModel<T>
            {
                Data = list,
                PageIndex = currentPage,
                PageSize = itemPerPage,
                TotalPage = list.PageCount,
                TotalItem = list.TotalItemCount,
            };
            return PagedList;
        }
    }
}
