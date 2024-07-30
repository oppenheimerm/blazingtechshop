
namespace BT.Core.Helpers.Paging
{
    /// <summary>
    /// Provides paging facilities to our repositories
    /// </summary>
    public class PagingParameters
    {
        /// <summary>
        /// Limit the page size to 20
        /// </summary>
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
