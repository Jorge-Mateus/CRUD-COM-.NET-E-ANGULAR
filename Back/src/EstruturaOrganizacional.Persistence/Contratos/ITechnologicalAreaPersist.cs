using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;

namespace EstruturaOrganizacional.Persistence
{
    public interface ITechnologicalAreaPersist
    {
        //Unidade opercional
        Task<TechnologicalArea[]> GetAllTechnologicalAreaAsync(bool includeUnidade = false);
        Task<TechnologicalArea[]> GetAllTechnologicalAreaByDescricaoAsync(string descricao, bool includeUnidade = false);
        Task<TechnologicalArea> GetAllTechnologicalAreaByIdAsync(int id, bool includeUnidade = false);
    }
}