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

    public class BusinessAreaService : IBusinessAreaService
    {
        private readonly IGeralPersist _geralPersist;
        private  readonly IBusinessAreaPersist _businessAreaPersist;
        private readonly IMapper _mapper;
        public BusinessAreaService(IGeralPersist geralPersist, 
                                   IBusinessAreaPersist businessAreaPersist,
                                   IMapper mapper)
        {
            _businessAreaPersist = businessAreaPersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
        }
        public async Task<BusinessAreaDto> AddBusinessArea(BusinessAreaDto model)
        {
            try
            {
                var businessarea = _mapper.Map<BusinessArea>(model);

                _geralPersist.Add<BusinessArea>(businessarea);

                if(await _geralPersist.SaveChangesAsyncs())
                {
                    var retorno = await _businessAreaPersist.GetAllBusinessAreaByIdAsync(businessarea.id, false);

                    return _mapper.Map<BusinessAreaDto>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
        }
        public async Task<BusinessAreaDto> UpdateBusinessArea(int id, BusinessAreaDto model)
        {
            try
            {
                var businessarea = await _businessAreaPersist.GetAllBusinessAreaByIdAsync(id);
                if(businessarea == null) return null;

                model.id = businessarea.id;

                _mapper.Map(model, businessarea);

                _geralPersist.Update<BusinessArea>(businessarea);

                if(await _geralPersist.SaveChangesAsyncs())
                {
                    var retorno = await _businessAreaPersist.GetAllBusinessAreaByIdAsync(businessarea.id, false);

                    return _mapper.Map<BusinessAreaDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var businessarea = await _businessAreaPersist.GetAllBusinessAreaByIdAsync(id);
                if(businessarea == null) throw new Exception ("A area de negocio não foi encontrada!");

                _geralPersist.Delete<BusinessArea>(businessarea);

                return await _geralPersist.SaveChangesAsyncs();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<BusinessAreaDto[]> GetAllBusinessAreaAsync(bool includeUnidad = false)
        {
            try
            {
                var businessareas = await _businessAreaPersist.GetAllBusinessAreaAsync(includeUnidad);
                if( businessareas == null )return null;

                var resultado = _mapper.Map<BusinessAreaDto[]>(businessareas);

                return resultado;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BusinessAreaDto[]> GetAllBusinessAreaBySiglaAsync(string sigla, bool includeUnidade = false)
        {
            try
            {
                var businessareas = await _businessAreaPersist.GetAllBusinessAreaBySiglaAsync(sigla,includeUnidade);
                if( businessareas == null )return null;
               
                var resultado = _mapper.Map<BusinessAreaDto[]>(businessareas);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BusinessAreaDto> GetAllBusinessAreaByIdAsync(int id, bool includeUnidade = false)
        {
            try
            {
                var businessarea = await _businessAreaPersist.GetAllBusinessAreaByIdAsync(id, includeUnidade);
                if( businessarea == null)return null;
                if(businessarea.IsDeleted == false){
                    return null;
                } 
                else
                {
                    var resultado = _mapper.Map<BusinessAreaDto>(businessarea);
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