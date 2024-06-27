using AutoMapper;
using CRUDCsharp.Dtos;
using CRUDCsharp.Models;
using CRUDCsharp.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CRUDCsharp.Services
{
    public class UserService : IUsersService
    {
        private StoreContext _storeContext;
        private IMapper _mapper;

        public UserService(StoreContext context, IMapper mapper)
                   {
            
            _storeContext = context;
            _mapper = mapper;

        }
        public async Task<IEnumerable<UserDto>> Get()=>
        

            await _storeContext.users.Select(u => _mapper.Map<UserDto>(u)).ToListAsync();
        

        public async Task<UserDto> GetById(int id)
        {
            var user = await _storeContext.users.FindAsync(id);

            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);

                return userDto;
            }



            return null;
        }

        public async Task<UserDto> Add(UserInsertDto userInsertDto)
        {

            var user = _mapper.Map<User>(userInsertDto);

            await _storeContext.users.AddAsync(user);
            await _storeContext.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;


        }

        private UserDto BadRequest(object errors)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> Update(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _storeContext.users.FindAsync(id);

            if (user != null)
            {
                user.Name = userUpdateDto.Name;
                user.email = userUpdateDto.email;
                user.age = userUpdateDto.age;
                user.city = userUpdateDto.city;
                user.country = userUpdateDto.country;
                user.phone = userUpdateDto.phone;

                await _storeContext.SaveChangesAsync();

                var userDto = _mapper.Map<UserDto>(user);

                return userDto;
            }

            return null;
        }

        public async Task<UserDto> Delete(int id)
        {
            var user = await _storeContext.users.FindAsync(id);

        if(user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                _storeContext.Remove(user);
                await _storeContext.SaveChangesAsync();

                return userDto;
            }

            return null;
        }

    }
}
