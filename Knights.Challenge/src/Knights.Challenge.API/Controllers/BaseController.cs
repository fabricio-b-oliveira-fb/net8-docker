using Knights.Challenge.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Knights.Challenge.API.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() { }

        protected IActionResult CustomResponse(string message)
        {
            var msg = string.IsNullOrWhiteSpace(message) 
                ? "Request successfully completed" 
                : message;

            return Ok(new ResponseDto
            {
                Result = msg
            });
        }

        protected IActionResult CustomResponse(object item)
        {
            var response = new ResponseDto();

            if (item is null)
            {
                ErrorRegister(response, "Request error. Check the request configurations");

                return BadRequest(response);
            }
            response.Result = item;

            return Ok(response);
        }

        private void ErrorRegister(ResponseDto response, string message)
        {
            response?.Error.Add(message);
        }
    }
}
