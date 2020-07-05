using Adapter.Interfaces;
using Application.Interfaces;
using Commons.Enums;
using Core.Services;
using DTO.DTO;
using System.Collections.Generic;
using System.Linq;

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

            var not_deleted = obj.Where(a => a.Erased == EStatusErased.NOT_DELETED);

            return _mapperUser.MapperToList(not_deleted);
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

        // methodes execution time
        public UserDTO Authenticate(string Password, string Username, string Email)
        {
            var obj = _serviceUser.GetAll();

            var user = obj.Where(x => (x.Username == Username || x.Email == Email) && x.Password == Password && x.Erased == EStatusErased.NOT_DELETED).FirstOrDefault();

            return _mapperUser.MapperToDTO(user);
        }

        public IEnumerable<UserDTO> GetAllErased()
        {
            var obj = _serviceUser.GetAll();

            var deleted = obj.Where(a => a.Erased == EStatusErased.DELETED);

            return _mapperUser.MapperToList(deleted);
        }

        public void DeactivateList(IEnumerable<UserDTO> obj)
        {
            var list = obj;

            foreach (var i in list)
            {
                var objUser = _mapperUser.MapperToEntity(i);

                if (objUser.Erased == EStatusErased.NOT_DELETED)
                {
                    objUser.Erased = EStatusErased.DELETED;
                }
                else
                {
                    objUser.Erased = EStatusErased.NOT_DELETED;
                }

                _serviceUser.Update(objUser);
            }
        }

        public void Deactivate(UserDTO userDTO)
        {
            var obj = _mapperUser.MapperToEntity(userDTO);

            if (obj.Erased == EStatusErased.NOT_DELETED)
            {
                obj.Erased = EStatusErased.DELETED;
            }
            else
            {
                obj.Erased = EStatusErased.NOT_DELETED;
            }

            _serviceUser.Update(obj);
        }
    }
}
