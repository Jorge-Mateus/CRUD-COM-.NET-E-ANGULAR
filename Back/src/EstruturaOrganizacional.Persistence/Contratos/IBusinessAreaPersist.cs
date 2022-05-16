using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;

namespace EstruturaOrganizacional.Persistence.Contratos
{
    public interface IBusinessAreaPersist
    {
        

        //UNIDADE de NEGOCIO
        Task<BusinessArea[]> GetAllBusinessAreaBySiglaAsync(string sigla, bool includeUnidade = false);
        Task<BusinessArea[]> GetAllBusinessAreaAsync(bool includeUnidade = false);
        Task<BusinessArea> GetAllBusinessAreaByIdAsync(int id, bool includeUnidade = false);


        
    }
}