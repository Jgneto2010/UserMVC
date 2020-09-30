using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositoy
{
    public class ClientRepository : RepositoryBase<Client>, IClient
    {
        public ClientRepository(EntityContext context) : base(context) { }

        public List<Client> GetAllClients()
        {
            return DbSet.ToList();
        }
    }
}
