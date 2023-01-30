using FluentValidation;

namespace CompareJson.Domain.Commands.JsonInBase64Right
{
	public class JsonInBase64RightCommandValidator : AbstractValidator<JsonInBase64RightCommand>
	{
		public JsonInBase64RightCommandValidator()
		{
			RuleFor(command => command.Base64).NotEmpty().WithMessage("It is necessary to inform a json in base64");
			RuleFor(command => command.Base64).NotNull().WithMessage("It is necessary to inform a json in base64");
		}
	}
}