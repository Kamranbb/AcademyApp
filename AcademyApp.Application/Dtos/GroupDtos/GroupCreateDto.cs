using FluentValidation;

namespace AcademyApp.Application.Dtos.GroupDtos
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public int Limit { get; set; }
    }
    public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>
    {
        public GroupCreateDtoValidator()
        {
            RuleFor(g=>g.Name).NotEmpty().MinimumLength(4).MaximumLength(5);
            RuleFor(g=>g.Limit).NotEmpty().InclusiveBetween(5,10);
        }
    }
}
