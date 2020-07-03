using Core.Repositories;
using Core.Services;
using Domain.Models;
using Services.Base;

namespace Services
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        public readonly IRepositoryUser _repositoryUser;

        public ServiceUser(IRepositoryUser repositoryUser) : base(repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }
    }
}
