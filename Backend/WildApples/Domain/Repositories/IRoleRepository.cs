﻿using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRoleRepository : ICRUDRepository<Role>
    {
        public Task<Role?> GetByName(string Name);
    }
}
