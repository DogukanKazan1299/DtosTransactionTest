using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {

        Task<List<User>> GetListAsync();
        Task<List<UserDtos>> GetDtoListAsync();
        Task<List<UserCreateDtos>> GetCreateDtoListAsync();

        Task<UserDtos> AddAsync(UserAddDto userAddDto);
        Task<UserUpdateDtos> UpdateAsync(UserUpdateDtos userUpdateDtos);

        Task<bool> DeleteAsync(int id);
    }
}
