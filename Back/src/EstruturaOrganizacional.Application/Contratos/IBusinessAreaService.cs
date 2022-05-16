using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;

namespace EstruturaOrganizacional.Application.Contratos
{
    public interface IBusinessAreaService
    {
        Task<BusinessArea> AddBusinessArea(BusinessArea model);
        Task<BusinessArea> UpdateBusinessArea(int id, BusinessArea model);
        Task<bool> Delete(int id);

        Task<BusinessArea[]> GetAllBusinessAreaAsync(bool includeUnidad = false);
        Task<BusinessArea[]> GetAllBusinessAreaBySiglaAsync(string sigla, bool includeUnidade = false);
        Task<BusinessArea> GetAllBusinessAreaByIdAsync(int id, bool includeUnidade = false);
        
    }
}