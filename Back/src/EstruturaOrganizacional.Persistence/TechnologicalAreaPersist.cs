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
        public async Task<TechnologicalArea[]> GetAllTechnologicalAreaBySiglaAsync(string descricao)
        {
            IQueryable<TechnologicalArea> query = _context.TECHNOLOGICALAREA
                    .Include(t => t.descricao);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(t => t.id);
            return await query.ToArrayAsync();
        }

        public async Task<TechnologicalArea[]> GetAllTechnologicalAreaAsync(string descricao)
        {
              IQueryable<TechnologicalArea> query = _context.TECHNOLOGICALAREA
                    .Include(t => t.descricao);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(t => t.id).Where(t => t.descricao.ToLower().Contains(descricao.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<TechnologicalArea> GetAllTechnologicalAreaByIdAsync(int id)
        {
            IQueryable<TechnologicalArea> query = _context.TECHNOLOGICALAREA
                    .Include(t => t.descricao);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(t => t.id)
                         .Where(t => t.id == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}