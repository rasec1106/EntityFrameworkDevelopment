namespace ApiStorage.DTOs
{
    public class StorageDto
    {
        public int StorageId { get; set; }
        public string? StorageName { get; set; }
        /* We will hide these properties */
        // public string? StorageAddress { get; set; }
        // public decimal? StorageCapacity { get; set; }
    }
}
