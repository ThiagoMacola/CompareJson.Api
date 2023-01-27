using CompareJson.Api.Domain.Commands.JsonInBase64Right;
using FluentValidation;

namespace CompareJson.Api.Domain.Commands.JsonInBase64Left
{
	public class JsonInBase64LeftCommandValidator : AbstractValidator<JsonInBase64RightCommand>
	{
		public JsonInBase64LeftCommandValidator()
		{
			RuleFor(command => command.Id).NotEmpty().WithMessage("It is necessary to inform an id");
			RuleFor(command => command.Base64).NotEmpty().WithMessage("It is necessary to inform a json in base64");
		}
	}
}