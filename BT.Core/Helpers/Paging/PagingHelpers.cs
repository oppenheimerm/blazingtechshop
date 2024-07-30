namespace BT.Core.Helpers.Paging
{
    public enum BrandSortOrder
    {
        Id,
        Name,
        Code
    }

    public static class PaginHelpers
    {
        /// <summary>
        /// Helpers function to convert <see cref="BrandSortOrder"/> from its interger value
        /// to it's enumeration value
        /// </summary>
        /// <param name="brandSortOrder"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static BrandSortOrder GetBrandSortOrder(int brandSortOrder)
        {
            BrandSortOrder sortOrder = brandSortOrder switch
            {
                0 => BrandSortOrder.Id,
                1 => BrandSortOrder.Name,
                2 => BrandSortOrder.Code,
                _ => throw new NotImplementedException(),
            };

            return sortOrder;
        }
    }

}
