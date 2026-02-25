namespace MultiTenantProject.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
