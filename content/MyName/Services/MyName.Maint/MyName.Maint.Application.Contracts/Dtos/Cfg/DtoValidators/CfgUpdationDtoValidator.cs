namespace MyName.Maint.Application.Contracts.DtoValidators;

public class CfgUpdationDtoValidator : AbstractValidator<CfgUpdationDto>
{
    public CfgUpdationDtoValidator()
    {
        Include(new CfgCreationDtoValidator());
    }
}