using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Application.Dtos;


namespace EstruturaOrganizacional.Application.Contratos
{
    public interface IOrganizationalStructureService
    {
        Task<OrganizationalStructureDtos> AddOrganization(OrganizationalStructureDtos model);
        Task<OrganizationalStructureDtos> UpdateOrganization(int id, OrganizationalStructureDtos model);
        Task<bool> Delete(int id, OrganizationalStructureDtos model);

        Task<OrganizationalStructureDtos[]> GetAllEstruturaOrganizacionalByAnoAsync(int ano, bool includeEstrutura); //todo por ano
        Task<OrganizationalStructureDtos[]> GetAllEstruturaOrganizacionalAnoAsync(bool includeEstrutura );
        Task<OrganizationalStructureDtos> GetAllOrganizationalStructureByIdAsync(int id, bool includeEstrutura = false);
    }
}