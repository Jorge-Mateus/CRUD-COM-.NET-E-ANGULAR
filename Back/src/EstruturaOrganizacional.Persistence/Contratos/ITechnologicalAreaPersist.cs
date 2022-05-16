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
        Task<TechnologicalArea[]> GetAllTechnologicalAreaBySiglaAsync(string descricao);
        Task<TechnologicalArea[]> GetAllTechnologicalAreaAsync(string descricao);
        Task<TechnologicalArea> GetAllTechnologicalAreaByIdAsync(int id);
    }
}