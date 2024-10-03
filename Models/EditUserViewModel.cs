namespace BlogPlatform.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string PublicName { get; set; }
        public string Bio {  get; set; }
        public DateOnly BirthDate { get; set; }

    }
}
