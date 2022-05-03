using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EstruturaOrganizacional.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
        public DbSet <BusinessArea> BusinessAreas{ get; set; }
    }
}