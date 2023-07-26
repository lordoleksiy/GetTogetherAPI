using GetTogether.BLL.Interfaces;
using GetTogether.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetTogether.WEBAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<UserDTO>>> GetAll() 
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("user")]
        public async Task<ActionResult<UserDTO>> GetUser()
        {
            var user = await _userService.GetUser();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody]NewUserDTO userDTO)
        {
            var user = await _userService.CreateUser(userDTO);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> Put([FromBody]UserDTO userDTO)
        {
            var user = await _userService.UpdateUser(userDTO);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<ActionResult<UserDTO>> DeleteUser()
        {
            var user = await _userService.DeleteUser();
            return Ok(user);
        }

        //[HttpPost("avatar")]
        //public async Task<ActionResult> UploadAvatar(IFormFile image)
        //{
        //    if (image.Validate())
        //    {
        //        NewImageDTO imgDTO = new NewImageDTO(image.OpenReadStream(), image.FileName, Common.Enums.ImageType.Avatars);
        //        return Ok(await _userService.UploadAvatar(imgDTO));
        //    }
        //    return BadRequest();
        //}
    }
}
