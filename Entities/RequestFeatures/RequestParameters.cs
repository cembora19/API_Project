namespace Entities.RequestFeatures
{
    public abstract partial class RequestParameters
    {
        const int maxPageSize = 50;

        //Auto-implemented property
        public int PageNumber { get; set; }
        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPageSize ? maxPageSize : value; }
        }
        public String? OrderBy { get; set; }
    }
}