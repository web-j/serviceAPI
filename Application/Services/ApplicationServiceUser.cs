using Adapter.Interfaces;
using Application.Interfaces;
using Core.Services;
using DTO.DTO;
using System.Collections.Generic;

namespace Application.Services
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IServiceUser _serviceUser;
        private readonly IMapperUser _mapperUser;

        public ApplicationServiceUser(IServiceUser serviceUser, IMapperUser mapperUser)
        {
            _serviceUser = serviceUser;
            _mapperUser = mapperUser;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var obj = _serviceUser.GetAll();
            return _mapperUser.MapperToList(obj);
        }

        public UserDTO GetById(int id)
        {
            var obj = _serviceUser.GetById(id);
            return _mapperUser.MapperToDTO(obj);
        }

        public void Add(UserDTO userDTO)
        {
            var obj = _mapperUser.MapperToEntity(userDTO);
            _serviceUser.Add(obj);
        }

        public void Update(UserDTO userDTO)
        {
            var obj = _mapperUser.MapperToEntity(userDTO);
            _serviceUser.Update(obj);
        }

        public void Remove(UserDTO userDTO)
        {
            var obj = _mapperUser.MapperToEntity(userDTO);
            _serviceUser.Remove(obj);
        }

        public void Dispose()
        {
            _serviceUser.Dispose();
        }
    }
}
