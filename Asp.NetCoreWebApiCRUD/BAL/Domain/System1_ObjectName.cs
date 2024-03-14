
namespace BAL.Domain
{
    //domain class its mapped with personEntity class
    public class System1_ObjectName
    {
        public int Id { get; set; }
        public string propertyName1 { get; set; }
        public string propertyName2 { get; set; }
        public string propertyName3 { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
