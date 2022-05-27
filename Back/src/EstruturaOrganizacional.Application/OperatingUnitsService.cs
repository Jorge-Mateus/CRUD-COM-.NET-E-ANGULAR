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
    public class OperatingUnitsService : IOperatingUnitService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IOperatingUnitPersist _operatingUnitPersist;
        private readonly IMapper _mapper;

        public OperatingUnitsService(IGeralPersist geralPersist, 
                                     IOperatingUnitPersist operatingUnitPersist,
                                     IMapper mapper)
        {
            _geralPersist = geralPersist;
            _mapper = mapper;
            _operatingUnitPersist = operatingUnitPersist;
        }

        public async Task<OperatingUnitsDtos> AddOperatingUnit(OperatingUnitsDtos model)
        {
            
            try
            {
                var operating = _mapper.Map<OperatingUnit>(model);
                operating.IsDeleted = false;

                _geralPersist.Add<OperatingUnit>(operating);

                if(await _geralPersist.SaveChangesAsyncs())
                {
                    var retorno = await _operatingUnitPersist.GetAllOperatingUnitByIdAsync(operating.id, false);
                    return _mapper.Map<OperatingUnitsDtos>(retorno);
                }

                return null;
            }
             catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
        }

        public async Task<OperatingUnitsDtos> UpdateOperatingUnit(int id, OperatingUnitsDtos model)
        {
            try
            {
                var operating = await _operatingUnitPersist.GetAllOperatingUnitByIdAsync(id);
                if(operating == null) return null;

                model.id = operating.id;

                _mapper.Map(model, operating);

              //  _geralPersist.Update<OperatingUnit>(operating);

                if(await _geralPersist.SaveChangesAsyncs()){

                    var retorno = await _operatingUnitPersist.GetAllOperatingUnitByIdAsync(operating.id, false);
                    
                    return _mapper.Map<OperatingUnitsDtos>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
        }

        public async Task<bool> Delete(int id, OperatingUnitsDtos model) {
            try
            {
                var operating = await _operatingUnitPersist.GetAllOperatingUnitByIdAsync(id);
                if(operating == null) return false;

                model.id = operating.id;

                _mapper.Map(model, operating);

                _geralPersist.Update<OperatingUnit>(operating);

                if(await _geralPersist.SaveChangesAsyncs()){

                    var retorno = await _operatingUnitPersist.GetAllOperatingUnitByIdAsync(operating.id, false);
                    
                    return true;
                }

                return await _geralPersist.SaveChangesAsyncs();
            }
             catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OperatingUnitsDtos[]> GetAllOperatingUnitBySiglaAsync(string sigla, bool includeUnidade = false)
        {
             try
            {
                var operating = await _operatingUnitPersist.GetAllOperatingUnitBySiglaAsync(sigla,includeUnidade);
                if( operating == null )return null;
               
                var resultado = _mapper.Map<OperatingUnitsDtos[]>(operating);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OperatingUnitsDtos[]> GetAllOperatingUnitAsync(bool includeUnidade = false)
        {
             try
            {
                var operating = await _operatingUnitPersist.GetAllOperatingUnitAsync(includeUnidade);
                if( operating == null )return null;

                var resultado = _mapper.Map<OperatingUnitsDtos[]>(operating);

                return resultado;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<OperatingUnitsDtos> GetAllOperatingUnitByIdAsync(int id, bool includeUnidade = false)
        {
            try
            {
                var operating = await _operatingUnitPersist.GetAllOperatingUnitByIdAsync(id, includeUnidade);
                if( operating == null)return null;
              
                else
                {
                    var resultado = _mapper.Map<OperatingUnitsDtos>(operating);
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