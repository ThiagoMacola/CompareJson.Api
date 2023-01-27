using FluentValidation;
using ServiceStack;
using ServiceStack.Text;

namespace CompareJson.Api.Domain.Commands.JsonInBase64Right
{
	public class JsonInBase64RightCommandValidator : AbstractValidator<JsonInBase64RightCommand>
	{
		public JsonInBase64RightCommandValidator()
		{
			RuleFor(command => command.Id).NotEmpty().WithMessage("It is necessary to inform an id");
			RuleFor(command => command.Base64).NotEmpty().WithMessage("It is necessary to inform a json in base64");
		}
	}
}