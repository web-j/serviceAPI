using DTO.DTO;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceUser
    {
        IEnumerable<UserDTO> GetAll();

        UserDTO GetById(int id);

        void Add(UserDTO obj);

        void Update(UserDTO obj);

        void Remove(UserDTO obj);

        void Dispose();
    }
}
