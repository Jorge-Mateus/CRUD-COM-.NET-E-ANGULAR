using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Application.Dtos;

namespace EstruturaOrganizacional.Application.Contratos
{
    public interface IOperatingUnitService
    {
        Task<OperatingUnitsDtos> AddOperatingUnit(OperatingUnitsDtos model);
        Task<OperatingUnitsDtos> UpdateOperatingUnit(int id, OperatingUnitsDtos model);
        Task<bool> Delete(int id, OperatingUnitsDtos model);
        //Unidade opercional
        Task<OperatingUnitsDtos[]> GetAllOperatingUnitBySiglaAsync(string sigla, bool includeUnidade = false);
        Task<OperatingUnitsDtos[]> GetAllOperatingUnitAsync(bool includeUnidade = false);
        Task<OperatingUnitsDtos> GetAllOperatingUnitByIdAsync(int id, bool includeUnidade = false);
    }
}