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
        public async Task<MarketArea[]> GetAllMarketAreaByDescricaoAsync(string descricao)
        {
            IQueryable<MarketArea> query = _context.MARKETAREA
                    .Include(am => am.descricao);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(am => am.id);
            return await query.ToArrayAsync();
        }

        public async Task<MarketArea[]> GetAllMarketAreaAsync(string descricao )
        {
            IQueryable<MarketArea> query = _context.MARKETAREA 
                    .Include(am => am.descricao);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(am => am.id).Where(am => am.descricao.ToLower().Contains(descricao.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<MarketArea> GetAllMarketAreaByIdAsync(int id)
        {
            IQueryable<MarketArea> query = _context.MARKETAREA 
                    .Include(am => am.descricao);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(am => am.id)
                         .Where(am => am.id == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}