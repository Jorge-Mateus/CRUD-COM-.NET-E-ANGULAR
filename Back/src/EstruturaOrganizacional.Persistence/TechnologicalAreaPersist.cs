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
    public class TechnologicalAreaPersist : ITechnologicalAreaPersist
    {
        private readonly EstruturaOrganizacionalContext _context;

        public TechnologicalAreaPersist(EstruturaOrganizacionalContext context)
        {
            _context = context;
            
        }

        //AREA DE TECNOLOGIA

           public async Task<TechnologicalArea[]> GetAllTechnologicalAreaAsync( bool includeUnidade = false)
        {
              IQueryable<TechnologicalArea> query = _context.TECHNOLOGICALAREA;

            query = query.AsNoTracking().OrderBy(t => t.id).Where(t => t.IsDeleted == false);
            return await query.ToArrayAsync();
        }

        public async Task<TechnologicalArea[]> GetAllTechnologicalAreaByDescricaoAsync(string descricao, bool includeUnidade = false)
        {
            IQueryable<TechnologicalArea> query = _context.TECHNOLOGICALAREA;
                   
            query = query.AsNoTracking().OrderBy(t => t.id).Where(t => t.IsDeleted == false && t.descricao.ToLower().Contains(descricao.ToLower()));

            return await query.ToArrayAsync();
        }

     

        public async Task<TechnologicalArea> GetAllTechnologicalAreaByIdAsync(int id, bool includeUnidade = false)
        {
            IQueryable<TechnologicalArea> query = _context.TECHNOLOGICALAREA;
            
            query = query.AsNoTracking().OrderBy(t => t.id).Where(t => t.IsDeleted == false && t.id == id);
            
            return await query.FirstOrDefaultAsync();
        }
    }
}