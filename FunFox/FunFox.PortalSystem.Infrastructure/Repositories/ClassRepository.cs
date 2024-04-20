using FunFox.PortalSystem.Application.Repositories;
using FunFox.PortalSystem.Domain.Entities;
using FunFox.PortalSystem.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFox.PortalSystem.Infrastructure.Repositories
{
    public class ClassRepository: GenericRepository<FunFoxClass>, IClassRepository
    {
        public ClassRepository(ApplicationDbContext context) : base(context) 
        { 
        }
    }
}
