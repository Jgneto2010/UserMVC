using Dapper;
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
        public readonly DapperContext _dapperContext;
        public ClientRepository(EntityContext context, DapperContext dapperContext) : base(context) 
        {
            _dapperContext = dapperContext;
        }

        public List<Client> GetAllDapperClients()
        {
            return _dapperContext.Connection.Query(@"SELECT * FROM Clients").Select(row =>
                 new Client((string)row.Name_Client, (string)row.Email, (string)row.CPF)
                 {
                     Id = (string)row.Id_Client
                 }).ToList();
        }
    }
}
