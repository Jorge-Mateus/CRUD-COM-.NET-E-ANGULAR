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
        public async Task<OperatingUnit[]> GetAllOperatingUnitBySiglaAsync(string sigla)
        {
            IQueryable<OperatingUnit> query = _context.OPERATINGUNIT
                    .Include(u => u.descricao)
                    .Include(u => u.codReduzido);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(u => u.id);
            return await query.ToArrayAsync();
        }
        public async Task<OperatingUnit[]> GetAllOperatingUnitAsync(string descricao)
        {
                IQueryable<OperatingUnit> query = _context.OPERATINGUNIT
                    .Include(u => u.descricao)
                    .Include(u => u.codReduzido);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(u => u.id).Where(am => am.descricao.ToLower().Contains(descricao.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<OperatingUnit> GetAllOperatingUnitByIdAsync(int OperatingUnitsID)
        {
            IQueryable<OperatingUnit> query = _context.OPERATINGUNIT
                    .Include(u => u.descricao)
                    .Include(u => u.codReduzido);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(u => u.id)
                         .Where(u => u.id == OperatingUnitsID);
            return await query.FirstOrDefaultAsync();
        }
    }
}