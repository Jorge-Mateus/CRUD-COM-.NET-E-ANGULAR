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
        Task<OperatingUnit[]> GetAllOperatingUnitBySiglaAsync(string sigla);
        Task<OperatingUnit[]> GetAllOperatingUnitAsync(string descricao);
        Task<OperatingUnit> GetAllOperatingUnitByIdAsync(int OperatingUnitsID);
    }
}