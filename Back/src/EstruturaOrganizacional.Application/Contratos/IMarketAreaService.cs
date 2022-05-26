using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Application.Dtos;

namespace EstruturaOrganizacional.Application.Contratos
{
    public interface IMarketAreaService
    {
        //CRUDMarketAreaDtos
        Task<MarketAreaDtos> AddMarketArea(MarketAreaDtos model);
        Task<MarketAreaDtos> UpdateMarketArea(int id, MarketAreaDtos model);
        Task<bool> Delete(int id, MarketAreaDtos model);
        //GET
        Task<MarketAreaDtos[]> GetAllMarketAreaByDescricaoAsync(string descricao, bool include = false);
        Task<MarketAreaDtos[]> GetAllMarketAreaAsync(bool include = false);
        Task<MarketAreaDtos> GetAllMarketAreaByIdAsync(int id,bool include = false);
    }
}