using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;
using Microsoft.EntityFrameworkCore;

namespace EstruturaOrganizacional.Persistence.Contextos
{
    public class EstruturaOrganizacionalContext : DbContext
    {
        public EstruturaOrganizacionalContext(DbContextOptions<EstruturaOrganizacionalContext> options) : base(options){ }
        public DbSet <BusinessArea> BUSINESSAREA{ get; set; }
        public DbSet <MarketArea> MARKETAREA{ get; set; }
        public DbSet <OperatingUnit> OPERATINGUNIT{ get; set; }
        public DbSet <TechnologicalArea> TECHNOLOGICALAREA{ get; set; }
        public DbSet <OrganizationalStructure> ORGANIZATIONALSTRUCTURE{ get; set; }

       protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrganizationalStructure>()
                .HasKey(OE => new {OE.BusinessAreasID, OE.MarketAreasId, 
                OE.OperatingUnitsID, OE.TchnologicalAreasID});
        }   

    }
}