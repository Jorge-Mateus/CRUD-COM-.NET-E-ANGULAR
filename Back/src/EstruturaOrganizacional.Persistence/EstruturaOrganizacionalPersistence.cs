using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;
using Microsoft.EntityFrameworkCore;

namespace EstruturaOrganizacional.Persistence
{
    public class EstruturaOrganizacionalPersistence : IEstruturaOrganizacionalPersistence
    {
        private readonly EstruturaOrganizacionalContext _context;
        public EstruturaOrganizacionalPersistence(EstruturaOrganizacionalContext context)
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
        //AREA DE NEGOCIO
        public async Task<BusinessArea[]> GetAllBusinessAreaBySiglaAsync(string sigla)
        {
            IQueryable<BusinessArea> query = _context.BUSINESSAREA 
                    .Include(an => an.sigla);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(an => an.id);
            return await query.ToArrayAsync();
        }

        public async Task<BusinessArea[]> GetAllBusinessAreaAsync(string sigla)
        {
            IQueryable<BusinessArea> query = _context.BUSINESSAREA 
                    .Include(an => an.sigla);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(an => an.id).Where(an => an.sigla.ToLower().Contains(sigla.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<BusinessArea> GetAllBusinessAreaByIdAsync(int id)
        {
            IQueryable<BusinessArea> query = _context.BUSINESSAREA 
                    .Include(an => an.sigla);

           /* if(includeEstrutura){
                query = query.Include(oe => oe.)
            }*/
            
            query = query.OrderBy(an => an.id)
                         .Where(an => an.id == id);
            return await query.FirstOrDefaultAsync();
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