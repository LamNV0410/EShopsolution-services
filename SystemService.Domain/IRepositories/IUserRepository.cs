﻿using EshopSolution.Extensions.BaseDbContext;
using SystemService.Domain.DomainModel;

namespace SystemService.Domain.IRepositories
{
    public interface IUserRepository : ICRUDRepository<User>,IRepository<User>
    {

    }
}
