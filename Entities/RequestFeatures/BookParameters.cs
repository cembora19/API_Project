namespace Entities.RequestFeatures
{
    public abstract partial class RequestParameters
    {
        public class BookParameters:RequestParameters
        {
            public uint MinPrice { get; set; }
            public uint MaxPrice { get; set; } = 1000;
            public bool ValidPriceRange => MaxPrice > MinPrice;
        }
    }
}