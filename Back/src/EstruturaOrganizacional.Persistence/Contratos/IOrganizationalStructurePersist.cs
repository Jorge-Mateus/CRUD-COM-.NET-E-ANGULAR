using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;

namespace EstruturaOrganizacional.Persistence.Contratos
{
    public interface IOrganizationalStructurePersist
    {
        //Estrutura Organizacional
        Task<OrganizationalStructure[]> GetAllEstruturaOrganizacionalByAnoAsync(int ano, bool includeEstrutura); //todo por ano
        Task<OrganizationalStructure[]> GetAllEstruturaOrganizacionalAnoAsync(bool includeEstrutura );
        Task<OrganizationalStructure> GetAllOrganizationalStructureByIdAsync(int id, bool includeEstrutura = false);

    }
}