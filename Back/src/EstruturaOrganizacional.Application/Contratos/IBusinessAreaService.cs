using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Application.Dtos;


namespace EstruturaOrganizacional.Application.Contratos
{
    public interface IBusinessAreaService
    {
        Task<BusinessAreaDto> AddBusinessArea(BusinessAreaDto model);
        Task<BusinessAreaDto> UpdateBusinessArea(int id, BusinessAreaDto model);
        Task<bool> Delete(int id, BusinessAreaDto model);

        Task<BusinessAreaDto[]> GetAllBusinessAreaAsync(bool includeUnidad = false);
        Task<BusinessAreaDto[]> GetAllBusinessAreaBySiglaAsync(string sigla, bool includeUnidade = false);
        Task<BusinessAreaDto> GetAllBusinessAreaByIdAsync(int id, bool includeUnidade = false);
        
    }
}