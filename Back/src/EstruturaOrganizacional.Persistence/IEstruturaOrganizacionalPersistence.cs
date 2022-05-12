using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;

namespace EstruturaOrganizacional.Persistence
{
    public interface IEstruturaOrganizacionalPersistence
    {
        //GERAL
        void Add<T> (T Entity) where T: class;
        void Update<T> (T Entity) where T: class;
        void Delete<T> (T Entity) where T: class;
        void DeleteRange<T> (T[] Entity) where T: class;
        Task<bool> SaveChangesAsyncs();

        //Estrutura Organizacional
        Task<OrganizationalStructure[]> GetAllEstruturaOrganizacionalByAnoAsync(int ano, bool includeEstrutura); //todo por ano
        Task<OrganizationalStructure[]> GetAllEstruturaOrganizacionalAnoAsync(bool includeEstrutura );
        Task<OrganizationalStructure>GetAllOrganizationalStructureByIdAsync(int id);

        //UNIDADE de NEGOCIO
        Task<BusinessArea[]> GetAllBusinessAreaBySiglaAsync(string sigla);
        Task<BusinessArea[]> GetAllBusinessAreaAsync(string sigla);
        Task<BusinessArea>GetAllBusinessAreaByIdAsync(int id);


        //Area de negocio
        Task<MarketArea[]> GetAllMarketAreaByDescricaoAsync(string descricao);
        Task<MarketArea[]> GetAllMarketAreaAsync(string descricao );
        Task<MarketArea>GetAllMarketAreaByIdAsync(int id);

        //Unidade opercional
        Task<OperatingUnit[]> GetAllOperatingUnitBySiglaAsync(string sigla);
        Task<OperatingUnit[]> GetAllOperatingUnitAsync(string descricao);
        Task<OperatingUnit>GetAllOperatingUnitByIdAsync(int OperatingUnitsID);

        //Unidade opercional
        Task<TechnologicalArea[]> GetAllTechnologicalAreaBySiglaAsync(string descricao);
        Task<TechnologicalArea[]> GetAllTechnologicalAreaAsync(string descricao);
        Task<TechnologicalArea>GetAllTechnologicalAreaByIdAsync(int id);
    }
}