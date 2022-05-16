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
            IQueryable<OrganizationalStructure> query = _context.ORGANIZATIONALSTRUCTURE
            .Include(OE => OE.BusinessArea)
            .Include(OE => OE.MarketArea)
            .Include(OE => OE.OperatingUnit)
            .Include(OE => OE.TchnologicalArea);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(OE => OE.id);
            return await query.ToArrayAsync();
        }
        public async Task<OrganizationalStructure[]> GetAllEstruturaOrganizacionalByAnoAsync(int ano, bool includeEstrutura)
        {
            IQueryable<OrganizationalStructure> query = _context.ORGANIZATIONALSTRUCTURE
                .Include(OE => OE.BusinessArea)
                .Include(OE => OE.MarketArea)
                .Include(OE => OE.OperatingUnit)
                .Include(OE => OE.TchnologicalArea);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(OE => OE.id)
                         .Where(OE => OE.ano.Year == ano);
            return await query.ToArrayAsync();
        }
        
        public async Task<OrganizationalStructure> GetAllOrganizationalStructureByIdAsync(int id)
        {
            IQueryable<OrganizationalStructure> query = _context.ORGANIZATIONALSTRUCTURE
                .Include(OE => OE.BusinessArea)
                .Include(OE => OE.MarketArea)
                .Include(OE => OE.OperatingUnit)
                .Include(OE => OE.TchnologicalArea);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(OE => OE.id)
                         .Where(OE => OE.id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}