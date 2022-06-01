using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstruturaOrganizacional.Application.Contratos;
using EstruturaOrganizacional.Application.Dtos;
using EstruturaOrganizacional.Domain;
using EstruturaOrganizacional.Persistence.Contratos;


namespace EstruturaOrganizacional.Application
{
    public class OrganizationalStructureService : IOrganizationalStructureService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;
        private readonly IOrganizationalStructurePersist _organizationalStructurePersit;

        public OrganizationalStructureService(IGeralPersist geralPersist, 
                                              IOrganizationalStructurePersist organizationalStructurePersit,
                                              IMapper mapper)
        {
            _geralPersist = geralPersist;
            _organizationalStructurePersit = organizationalStructurePersit;
            _mapper = mapper;
        }

        public async Task<OrganizationalStructureDtos> AddOrganization(OrganizationalStructureDtos model)
        {
            try
            {
                var organization = _mapper.Map<OrganizationalStructure>(model);
                
                organization.IsDeleted = false;

                _geralPersist.Add<OrganizationalStructure>(organization);


                if(await _geralPersist.SaveChangesAsyncs())
                {
                    var retorno = await _organizationalStructurePersit.GetAllOrganizationalStructureByIdAsync(organization.id, false);
                  
                    return _mapper.Map<OrganizationalStructureDtos>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
     
        }

        public async Task<OrganizationalStructureDtos> UpdateOrganization(int id, OrganizationalStructureDtos model)
        {
            try
            {
                var organization = await _organizationalStructurePersit.GetAllOrganizationalStructureByIdAsync(id);
                if(organization == null) return null;

                model.id = organization.id;

                _mapper.Map(model, organization);

                _geralPersist.Update<OrganizationalStructure>(organization);

                if(await _geralPersist.SaveChangesAsyncs())
                {
                    var retorno = await _organizationalStructurePersit.GetAllOrganizationalStructureByIdAsync(organization.id, false);

                    return _mapper.Map<OrganizationalStructureDtos>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id, OrganizationalStructureDtos model)
        {
            try{
                var organization = await _organizationalStructurePersit.GetAllOrganizationalStructureByIdAsync(id);
                if(organization == null) return false;

                model.id = organization.id;

                _mapper.Map(model, organization);

                _geralPersist.Update<OrganizationalStructure>(organization);

                if(await _geralPersist.SaveChangesAsyncs()){
                
                    var retorno = await _organizationalStructurePersit.GetAllOrganizationalStructureByIdAsync(organization.id, false);

                    return true;
                }

                return await _geralPersist.SaveChangesAsyncs();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrganizationalStructureDtos[]> GetAllEstruturaOrganizacionalAnoAsync(bool includeEstrutura = false)
        {
            try
            {
                var organization = await _organizationalStructurePersit.GetAllEstruturaOrganizacionalAnoAsync(includeEstrutura);
                if( organization == null )return null;

                var resultado = _mapper.Map<OrganizationalStructureDtos[]>(organization);

                return resultado;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrganizationalStructureDtos[]> GetAllEstruturaOrganizacionalByAnoAsync(int ano, bool includeEstrutura = false)
        {
            try
            {
                var organization = await _organizationalStructurePersit.GetAllEstruturaOrganizacionalByAnoAsync(ano,includeEstrutura);
                if( organization == null )return null;
               
                var resultado = _mapper.Map<OrganizationalStructureDtos[]>(organization);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrganizationalStructureDtos> GetAllOrganizationalStructureByIdAsync(int id, bool includeEstrutura = false)
        {
            try
            {
                var organization = await _organizationalStructurePersit.GetAllOrganizationalStructureByIdAsync(id, includeEstrutura);
                if( organization == null)return null;
              
                else
                {
                    var resultado = _mapper.Map<OrganizationalStructureDtos>(organization);
                    return resultado;
                }

              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }
    }
}