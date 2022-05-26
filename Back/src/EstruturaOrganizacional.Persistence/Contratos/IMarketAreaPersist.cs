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
        Task<MarketArea[]> GetAllMarketAreaByDescricaoAsync(string descricao, bool include = false);
        Task<MarketArea[]> GetAllMarketAreaAsync(bool include = false);
        Task<MarketArea> GetAllMarketAreaByIdAsync(int id,bool include = false);
    }
}