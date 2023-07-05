namespace QueueMinder.Domain.Interfaces
{
    public interface IBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
