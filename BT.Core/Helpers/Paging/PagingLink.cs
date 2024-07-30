
namespace BT.Core.Helpers.Paging
{
    public class PagingLink
    {
        /// <summary>
        /// Text property is for every button text in the pagination component 
        /// (Previous, Next, 1,2,3…).
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        ///  property will hold the value of the current page.
        /// </summary>
        public int Page { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }
        public PagingLink(int page, bool enabled, string text)
        {
            Page = page;
            Enabled = enabled;
            Text = text;
        }
    }
}
