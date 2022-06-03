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

        private void ModelCreateNature(ModelBuilder builder) {

              builder.Entity<OrganizationalStructure>()

                .HasOne(p => p.BusinessAreas)

                .WithMany(p => p.Organizacao)

                .HasForeignKey(p => p.BusinessAreaId);

            builder.Entity<OrganizationalStructure>()

                .HasOne(p => p.MarketAreas)

                .WithMany(p => p.Organizacao)

                .HasForeignKey(p => p.MarketAreaID);

            builder.Entity<OrganizationalStructure>()

                .HasOne(p => p.OperatingUnits)

                .WithMany(p => p.Organizacao)

                .HasForeignKey(p => p.OperatingUnitsId);

            builder.Entity<OrganizationalStructure>()

                .HasOne(p => p.TchnologicalAreas)

                .WithMany(p => p.Organizacao)

                .HasForeignKey(p => p.TechnologicalAreaId);

        }

       

        
    }
}
