using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;

namespace EstruturaOrganizacional.Persistence.Contratos
{
    public interface IMarketAreaPersist
    {
        
        //Area de negocio
        Task<MarketArea[]> GetAllMarketAreaByDescricaoAsync(string descricao);
        Task<MarketArea[]> GetAllMarketAreaAsync(string descricao );
        Task<MarketArea> GetAllMarketAreaByIdAsync(int id);
    }
}