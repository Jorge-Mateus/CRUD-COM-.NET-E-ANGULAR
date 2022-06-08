using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;
using Microsoft.EntityFrameworkCore;
using EstruturaOrganizacional.Persistence.Contextos;
using EstruturaOrganizacional.Persistence.Contratos;


namespace EstruturaOrganizacional.Persistence
{
    public class OrganizationalStructurePersist : IOrganizationalStructurePersist
    {
        private readonly EstruturaOrganizacionalContext _context;

        public OrganizationalStructurePersist(EstruturaOrganizacionalContext context)
        {
            _context = context;
            
        }
        //ESTRUTURA ORGANIZACIONL
        public async Task<OrganizationalStructure[]> GetAllEstruturaOrganizacionalAnoAsync(bool includeEstrutura = false)
        {
            IQueryable<OrganizationalStructure> query = _context.ORGANIZATIONALSTRUCTURE;

            OrganizationalStructure obj = new OrganizationalStructure();
            BusinessArea ba = new BusinessArea();

            obj.BusinessAreaId = ba.id;
                                                
            query = query.AsNoTracking().OrderBy(OE => OE.id).Where(o => o.IsDeleted == false);
            
            return await query.ToArrayAsync();
        }
        public async Task<OrganizationalStructure[]> GetAllEstruturaOrganizacionalByAnoAsync(int ano, bool includeEstrutura = false)
        {
           IQueryable<OrganizationalStructure> query = _context.ORGANIZATIONALSTRUCTURE;                                            

            query =  query.AsNoTracking().OrderBy(OE => OE.id).Where(OE => OE.IsDeleted == false && OE.ano == ano);
            return await query.ToArrayAsync();
        }
        
        public async Task<OrganizationalStructure> GetAllOrganizationalStructureByIdAsync(int id, bool includeEstrutura = false)
        {
            IQueryable<OrganizationalStructure> query = _context.ORGANIZATIONALSTRUCTURE;
            

            query = query.AsNoTracking().OrderBy(OE => OE.id).Where(OE => OE.IsDeleted == false && OE.id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}