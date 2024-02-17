namespace FirstSpaceApi.Shared.Models
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
