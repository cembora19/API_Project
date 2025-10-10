namespace Entities.DataTransferObjects
{
    public record BookDtoForUpdate
    {
        public int IsDevelopment { get; init; }
        public String? Title { get; init; }
        public decimal Price { get; init; }
    }
}