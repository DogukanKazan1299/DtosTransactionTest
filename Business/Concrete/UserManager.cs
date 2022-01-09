using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<UserDtos> AddAsync(UserAddDto userAddDto)
        {
            User user = new User()
            {
                Name = userAddDto.Name,
                Surname=userAddDto.Surname,
                Address=userAddDto.Address,
                Age=userAddDto.Age,
                CreatedDate=DateTime.Now,
                CreatedUserId=3,
                DateOfBirth=userAddDto.DateOfBirth,
                Email=userAddDto.Email,
                Gender=userAddDto.Gender,
                Password=userAddDto.Password
            };
            var userAdd = await _userDal.AddAsync(user);
            UserDtos userDtos = new UserDtos()
            {
                Name = userAdd.Name,
                Surname = userAdd.Surname,
                Address = userAdd.Address,
                Age = userAdd.Age,
                CreatedDate = DateTime.Now,
                CreatedUserId = 3,
                DateOfBirth = userAdd.DateOfBirth,
                Email = userAdd.Email,
                Gender = userAdd.Gender,
                Password = userAdd.Password
            };
            return userDtos;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDal.DeleteAsync(id);
        }

        public async Task<List<UserCreateDtos>> GetCreateDtoListAsync()
        {
            List<UserCreateDtos> userDetailDtos = new List<UserCreateDtos>();
            var response = await _userDal.GetListAsync();
            foreach (var item in response.ToList())
            {
                userDetailDtos.Add(new UserCreateDtos()
                {
                    Name = item.Name,
                    Surname = item.Surname,
                    Age = item.Age,
                    Gender = item.Gender,
                    CreatedDate = DateTime.Now,
                    CreatedUserId = 2,
                    Email = item.Email,
                    Password = item.Password,
                    DateOfBirth = item.DateOfBirth,
                    Address = item.Address
                });

            }
            return userDetailDtos;
        }

        public async Task<List<UserDtos>> GetDtoListAsync()
        {
            List<UserDtos> userDetailDtos = new List<UserDtos>();
            var response = await _userDal.GetListAsync();
            foreach (var item in response.ToList())
            {
                userDetailDtos.Add(new UserDtos()
                {
                    Name=item.Name,
                    Surname=item.Surname,
                    Age=item.Age,
                    Gender=item.Gender,
                    CreatedDate=item.CreatedDate,
                    CreatedUserId=item.CreatedUserId,
                    Email=item.Email,
                    Password=item.Password,
                    DateOfBirth=item.DateOfBirth,
                    Address=item.Address
                });
            }
            return userDetailDtos;
        }

        public async Task<List<User>> GetListAsync()
        {
            var result = await _userDal.GetListAsync();
            return result;
        }

        public async Task<UserUpdateDtos> UpdateAsync(UserUpdateDtos userUpdateDtos)
        {
            var getUser = await _userDal.GetByIdAsync(x => x.Id == userUpdateDtos.Id);
            User user = new User()
            {
                Id=userUpdateDtos.Id,
                Address = userUpdateDtos.Address,
                Age = userUpdateDtos.Age,
                CreatedDate = getUser.CreatedDate,
                CreatedUserId = getUser.CreatedUserId,
                DateOfBirth = userUpdateDtos.DateOfBirth,
                Email = userUpdateDtos.Email,
                Gender=userUpdateDtos.Gender,
                Name=userUpdateDtos.Name,
                Surname=userUpdateDtos.Surname,
                Password=userUpdateDtos.Password
            };
            var userUpdate = await _userDal.Update(user);
            UserUpdateDtos newUser = new UserUpdateDtos()
            {
                Id=userUpdate.Id,
                Address = userUpdate.Address,
                Age = userUpdate.Age,
                CreatedDate = getUser.CreatedDate,
                CreatedUserId = getUser.CreatedUserId,
                DateOfBirth = userUpdate.DateOfBirth,
                Email = userUpdate.Email,
                Gender = userUpdate.Gender,
                Name = userUpdate.Name,
                Surname = userUpdate.Surname,
                Password = userUpdate.Password
            };
            return newUser;
        }
    }
}
