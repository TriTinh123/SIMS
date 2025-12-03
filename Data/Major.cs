namespace SIMS.Data
{
    public class Major
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
