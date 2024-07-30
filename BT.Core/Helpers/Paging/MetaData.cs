
namespace BT.Core.Helpers.Paging
{
    public class MetaData
    {
        public int CurrentPage { get; set; }
        /// <summary>
        /// TotalPages is calculated by dividing the number of items by the page 
        /// size and then rounding it to the larger number since a page needs to 
        /// exist even if there is just one item on it.
        /// </summary>
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        /// <summary>
        /// HasPrevious is true if <see cref="CurrentPage"/> is larger than 1.
        /// </summary>
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
