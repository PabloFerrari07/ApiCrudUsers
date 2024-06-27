using CRUDCsharp.Dtos;
using CRUDCsharp.Models;
using CRUDCsharp.Services;
using CRUDCsharp.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private StoreContext _storeContext;
        private IUsersService _UserService;
        private IValidator<UserInsertDto> _userInsertValidator;
        public UserController(StoreContext context,
                               IUsersService userService, IValidator<UserInsertDto> userInsertValdiator) {
            _storeContext = context;
            _UserService = userService;
            _userInsertValidator = userInsertValdiator;
        }
        //METODO GET
        [HttpGet]

        public async Task<IEnumerable<UserDto>> Get() => await _UserService.Get();

        //METODO GETBYID

        [HttpGet("{id}")]

        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var userDto = await _UserService.GetById(id);
            return userDto == null ? NotFound() : userDto;
        }

        //METODO POST

        [HttpPost]
        public async Task<ActionResult<UserDto>> Add(UserInsertDto userInsertDto) {
            var validatorResult = await _userInsertValidator.ValidateAsync(userInsertDto);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var userDto = await _UserService.Add(userInsertDto);
            return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);

        }

        //METODO UPDATE

        [HttpPut("{id}")]

        public async Task<ActionResult<UserDto>>Update(int id,UserUpdateDto userUpdateDto)
        {
            var userDto = await _UserService.Update(id,userUpdateDto);

            return userDto == null ? NotFound() : Ok(userDto);
        }

        //METODO DELETE
        [HttpDelete("{id}")]

        public async Task<ActionResult>Delete(int id)
        {
                var userDto = await _UserService.Delete(id);
            return userDto == null ? NotFound() : Ok(userDto);

        }

    }
}
