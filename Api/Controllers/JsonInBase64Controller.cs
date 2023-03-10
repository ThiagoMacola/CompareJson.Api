using CompareJson.Domain.Commands.JsonInBase64Left;
using CompareJson.Domain.Commands.JsonInBase64Right;
using CompareJson.Domain.Querys.JsonCompare;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CompareJson.Api.Controllers
{
	[Route("api/v1/")]
	[ApiController]
	public class JsonInBase64Controller : ControllerBase
	{
		private readonly IMediator _mediatorService;

		public JsonInBase64Controller(IMediator mediatorService)
		{
			_mediatorService = mediatorService;
		}

		[HttpPost("diff/{id}/right")]
		[ProducesResponseType(typeof(JsonInBase64RightCommandResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> InsertJsonInBase64Right([FromRoute] int id, [FromBody] JsonInBase64RightCommand request)
		{
			request.Id = id;
			return Ok(await _mediatorService.Send(request));
		}

		[HttpPost("diff/{id}/left")]
		[ProducesResponseType(typeof(JsonInBase64LeftCommandResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> InsertJsonInBase64Left(int id, [FromBody] JsonInBase64LeftCommand request)
		{
			request.Id = id;
			return Ok(await _mediatorService.Send(request));
		}

		[HttpGet("diff/{id}")]
		[ProducesResponseType(typeof(JsonInBase64LeftCommandResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> CompareJson([FromRoute] int id)
		{
			var request = new JsonCompareQuery(id);
			return Ok(await _mediatorService.Send(request));
		}
	}
}