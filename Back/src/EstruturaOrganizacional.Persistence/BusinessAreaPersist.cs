using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;
using EstruturaOrganizacional.Persistence.Contextos;
using EstruturaOrganizacional.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace EstruturaOrganizacional.Persistence
{
    public class BusinessAreaPersist : IBusinessAreaPersist
    {
        private readonly EstruturaOrganizacionalContext _context;

        public BusinessAreaPersist(EstruturaOrganizacionalContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;            
        }
        
        //AREA DE NEGOCIO
        public async Task<BusinessArea[]> GetAllBusinessAreaAsync(bool includeUnidade = false)
        {
            IQueryable<BusinessArea> query = _context.BUSINESSAREA;

            query = query.AsNoTracking().OrderBy(an => an.id);

            return await query.ToArrayAsync();
        }

        public async Task<BusinessArea[]> GetAllBusinessAreaBySiglaAsync(string sigla, bool includeUnidade = false)
        {
           IQueryable<BusinessArea> query = _context.BUSINESSAREA;

           
            query = query.AsNoTracking().OrderBy(an => an.id).Where(an => an.sigla.ToLower().Contains(sigla.ToLower()));

            return await query.ToArrayAsync();
        }
        
        public async Task<BusinessArea> GetAllBusinessAreaByIdAsync(int id,bool includeUnidade = false)
        {
            IQueryable<BusinessArea> query = _context.BUSINESSAREA;
            
            query = query.AsNoTracking().OrderBy(an => an.id).Where(an => an.id == id);
                         
            return await query.FirstOrDefaultAsync();
        }
    }
}