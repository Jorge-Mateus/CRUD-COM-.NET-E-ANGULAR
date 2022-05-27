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
    public class OperatingUnitPersist : IOperatingUnitPersist
    {
        private readonly EstruturaOrganizacionalContext _context;
        
        public OperatingUnitPersist(EstruturaOrganizacionalContext context)
        {
            _context = context;
            
        }
        
        // UNIDADE OPERACIONAL

        public async Task<OperatingUnit[]> GetAllOperatingUnitAsync(bool includeUnidade = false)
        {

                IQueryable<OperatingUnit> query = _context.OPERATINGUNIT;
                
                query = query.AsNoTracking().OrderBy(u => u.id).Where(u => u.IsDeleted == false);
           
                return await query.ToArrayAsync();
        }
       
        public async Task<OperatingUnit[]> GetAllOperatingUnitBySiglaAsync(string sigla,bool includeUnidade = false)
        {
            IQueryable<OperatingUnit> query = _context.OPERATINGUNIT;  

            query = query.AsNoTracking().OrderBy(u => u.id).Where(u => u.IsDeleted == false &&
                                                   u.sigla.ToLower().Contains(sigla.ToLower()));
            return await query.ToArrayAsync();
        }
     
        public async Task<OperatingUnit> GetAllOperatingUnitByIdAsync(int id, bool includeUnidade = false)
        {
            IQueryable<OperatingUnit> query = _context.OPERATINGUNIT;
           
            query =query.AsNoTracking().OrderBy(u => u.id).Where(u => u.IsDeleted == false && u.id == id);
            
            return await query.FirstOrDefaultAsync();
        }
    }
}