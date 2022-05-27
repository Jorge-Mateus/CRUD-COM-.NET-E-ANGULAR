using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Application.Dtos;

namespace EstruturaOrganizacional.Application.Contratos
{
    public interface ITechnologicalAreaService
    {
        Task<TechnologicalAreaDtos> AddTechnologicalArea(TechnologicalAreaDtos model);
        Task<TechnologicalAreaDtos> UpdateTechnologicalArea(int id, TechnologicalAreaDtos model);
        Task<bool> Delete(int id, TechnologicalAreaDtos model);
        //Unidade de tecnologia-TechnologicalAreaDtos
        Task<TechnologicalAreaDtos[]> GetAllTechnologicalAreaAsync(bool includeUnidade = false);
        Task<TechnologicalAreaDtos[]> GetAllTechnologicalAreaByDescricaoAsync(string descricao, bool includeUnidade = false);
        Task<TechnologicalAreaDtos> GetAllTechnologicalAreaByIdAsync(int id, bool includeUnidade = false);
    }
}