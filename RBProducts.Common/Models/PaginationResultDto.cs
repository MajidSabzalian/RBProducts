using RBProducts.Common.Interfaces;

namespace RBProducts.Common.Models
{
    public class PaginationResultDto<T> : IPaginationResult
    {
        public int RowCount { set; get; }
        public int PageCount { set; get; }
        public int PageSize { set; get; }
        public int Page { set; get; }
        public List<T> Items { set; get; }
    }
    public class DataResultDto<T> : IPaginationResult
    {
        public int RowCount { set; get; }
        public int PageCount { set; get; }
        public int PageSize { set; get; }
        public int Page { set; get; }
        public List<T> Items { set; get; }
    }
}
