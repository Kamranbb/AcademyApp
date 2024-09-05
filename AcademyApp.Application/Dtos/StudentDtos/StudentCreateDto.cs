using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AcademyApp.Application.Dtos.StudentDtos
{
    public class StudentCreateDto
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public IFormFile File { get; set; }
        public string Email { get; set; }
        public int GroupId { get; set; }
    }
    public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidator()
        {
            RuleFor(s=>s.Name)
                .MinimumLength(5)
                .MaximumLength(35)
                .NotEmpty();

            RuleFor(s => s.Email)
                .MinimumLength(5)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(s => s.BirthDate.Date)
                .LessThanOrEqualTo(DateTime.Now.AddYears(-15));

            RuleFor(s => s).Custom((s, c) =>
            {
                if (s.Name!=null&& !char.IsUpper(s.Name[0]))
                {
                    c.AddFailure(nameof(s.Name), "FullName must be start with uppercase");
                }
            });

            RuleFor(s => s).Custom((s, c) =>
            {
                if (s.File!=null && s.File.Length/1024>300)
                {
                    c.AddFailure("File", "File size too large..");
                }
                if (s.File != null && !s.File.ContentType.Contains("image/"))
                {
                    c.AddFailure("File", "File type must be image..");
                }
            });

        }
    }
}
