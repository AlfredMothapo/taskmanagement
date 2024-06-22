
namespace TaskManagement.BL.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public List<TaskModel> Tasks { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
