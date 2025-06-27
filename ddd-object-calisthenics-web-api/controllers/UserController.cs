using System.Net;
using ddd_object_calisthenics_web_api.application.dtos;
using ddd_object_calisthenics_web_api.application.dtos.responses;
using ddd_object_calisthenics_web_api.application.use_cases.user.create;
using ddd_object_calisthenics_web_api.application.use_cases.user.read;
using ddd_object_calisthenics_web_api.shared.dtos;
using ddd_object_calisthenics_web_api.shared.extensions;
using Microsoft.AspNetCore.Mvc;

namespace ddd_object_calisthenics_web_api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, [FromServices] ICreateUserUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return this.ToSuccessResponse((int)HttpStatusCode.Created, response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUser([FromRoute] string id, [FromServices] IGetUserUseCase useCase)
        {
            var response = await useCase.Execute(id);

            if(response == null)
                return this.ToSuccessResponse((int)HttpStatusCode.NoContent);

            return this.ToSuccessResponse((int)HttpStatusCode.Created, response);
        }
    }
}
