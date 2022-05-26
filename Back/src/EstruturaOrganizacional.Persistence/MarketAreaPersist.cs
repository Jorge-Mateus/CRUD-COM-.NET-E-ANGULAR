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
    public class MarketAreaPersist : IMarketAreaPersist
    {
        private readonly EstruturaOrganizacionalContext _context;

        public MarketAreaPersist(EstruturaOrganizacionalContext context)
        {
            _context = context;
            
        }
        
        // AREA DE MERCADO
         public async Task<MarketArea[]> GetAllMarketAreaAsync(bool include = false )
        {
           IQueryable<MarketArea> query = _context.MARKETAREA;

            query = query.AsNoTracking().OrderBy(am => am.id).Where(am => am.IsDeleted == false);

            return await query.ToArrayAsync();
        }
        
        public async Task<MarketArea[]> GetAllMarketAreaByDescricaoAsync(string descricao, bool include = false)
        {
             IQueryable<MarketArea> query = _context.MARKETAREA;

           
            query = query.AsNoTracking().OrderBy(am => am.id).Where(am => am.IsDeleted == false && am.descricao.ToLower().Contains(descricao.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<MarketArea> GetAllMarketAreaByIdAsync(int id,bool include = false)
        {
           IQueryable<MarketArea> query = _context.MARKETAREA;
            
            query = query.AsNoTracking().OrderBy(am => am.id).Where(am => am.IsDeleted == false && am.id == id );
                         
            return await query.FirstOrDefaultAsync();
        }
    }
}