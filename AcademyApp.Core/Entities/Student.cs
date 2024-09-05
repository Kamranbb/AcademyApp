namespace AcademyApp.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
