using BAL.Domain;

namespace BAL.Requests
{
    public class CreatePersonRequest
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
