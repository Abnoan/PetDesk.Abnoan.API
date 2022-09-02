using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDesk.Abnoan.Infrastructure.Persistence
{
    public class PetDeskDbContext : DbContext
    {
        public PetDeskDbContext(DbContextOptions<PetDeskDbContext> options) : base(options)
        {

        }
    }
}
