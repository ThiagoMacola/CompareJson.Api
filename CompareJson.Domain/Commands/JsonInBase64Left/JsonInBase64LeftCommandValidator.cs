using FluentValidation;

namespace CompareJson.Domain.Commands.JsonInBase64Left
{
	public class JsonInBase64LeftCommandValidator : AbstractValidator<JsonInBase64LeftCommand>
	{
		public JsonInBase64LeftCommandValidator()
		{
			RuleFor(command => command.Base64).NotEmpty().WithMessage("It is necessary to inform a json in base64");
			RuleFor(command => command.Base64).NotNull().WithMessage("It is necessary to inform a json in base64");
		}
	}
}