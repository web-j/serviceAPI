using Domain.Models;
using DTO.DTO;
using System.Collections.Generic;

namespace Adapter.Interfaces
{
    public interface IMapperUser
    {
        User MapperToEntity(UserDTO userDTO);

        IEnumerable<UserDTO> MapperToList(IEnumerable<User> users);

        UserDTO MapperToDTO(User user);
    }
}
