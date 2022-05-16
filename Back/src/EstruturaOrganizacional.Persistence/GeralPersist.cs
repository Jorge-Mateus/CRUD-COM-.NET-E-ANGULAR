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
    public class GeralPersist : IGeralPersist
    {
        private readonly EstruturaOrganizacionalContext _context;
        public GeralPersist(EstruturaOrganizacionalContext context)
        {
            _context = context;
            
        }
        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public void Update<T>(T Entity) where T : class
        {
            _context.Update(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }

        public void DeleteRange<T>(T[] EntityArray) where T : class
        {
            _context.RemoveRange(EntityArray);
        }
        public async Task<bool> SaveChangesAsyncs()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
    
}