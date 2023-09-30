namespace RBProducts.Common.Interfaces
{
    public interface IPaginationResult
    {
        int RowCount { set; get; }
        int PageCount { set; get; }
        int PageSize { set; get; }
        int Page { set; get; }
    }
}
