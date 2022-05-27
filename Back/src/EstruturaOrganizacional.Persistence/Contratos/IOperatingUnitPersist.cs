using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;

namespace EstruturaOrganizacional.Persistence.Contratos
{
    public interface IOperatingUnitPersist
    {
        
        //Unidade opercional
        Task<OperatingUnit[]> GetAllOperatingUnitBySiglaAsync(string sigla, bool includeUnidade = false);
        Task<OperatingUnit[]> GetAllOperatingUnitAsync(bool includeUnidade = false);
        Task<OperatingUnit> GetAllOperatingUnitByIdAsync(int id, bool includeUnidade = false);
    }
}