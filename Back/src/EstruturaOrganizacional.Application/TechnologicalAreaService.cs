using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstruturaOrganizacional.Application.Contratos;
using EstruturaOrganizacional.Application.Dtos;
using EstruturaOrganizacional.Domain;
using EstruturaOrganizacional.Persistence.Contratos;
using EstruturaOrganizacional.Persistence;

namespace EstruturaOrganizacional.Application
{
    public class TechnologicalAreaService : ITechnologicalAreaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ITechnologicalAreaPersist _technologicalAreaPersist;
        private readonly IMapper _mapper;

        public TechnologicalAreaService(IGeralPersist geralPersist,
                                        ITechnologicalAreaPersist technologicalAreaPersist,
                                        IMapper mapper)
        {
            _technologicalAreaPersist = technologicalAreaPersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
        }

        public async Task<TechnologicalAreaDtos> AddTechnologicalArea(TechnologicalAreaDtos model)
        {
            try
            {
                var technological = _mapper.Map<TechnologicalArea>(model);
                _geralPersist.Add<TechnologicalArea>(technological);
                technological.IsDeleted = false;
                if (await _geralPersist.SaveChangesAsyncs())
                {
                    var retorno = await _technologicalAreaPersist.GetAllTechnologicalAreaByIdAsync(technological.id, false);

                    return _mapper.Map<TechnologicalAreaDtos>(retorno);
                }
                 return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public async Task<TechnologicalAreaDtos> UpdateTechnologicalArea(int id, TechnologicalAreaDtos model)
        {
            try
            {
                var technological = await _technologicalAreaPersist.GetAllTechnologicalAreaByIdAsync(id);
                if(technological == null) return null;

                model.id = technological.id;

                _mapper.Map(model, technological);

                _geralPersist.Update<TechnologicalArea>(technological);

                if(await _geralPersist.SaveChangesAsyncs())
                {
                    var retorno = await _technologicalAreaPersist.GetAllTechnologicalAreaByIdAsync(technological.id, false);

                    return _mapper.Map<TechnologicalAreaDtos>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id, TechnologicalAreaDtos model)
        {
            try{
                var technological = await _technologicalAreaPersist.GetAllTechnologicalAreaByIdAsync(id);
                if(technological == null) return false;

                model.id = technological.id;

                _mapper.Map(model, technological);

                _geralPersist.Update<TechnologicalArea>(technological);

                if(await _geralPersist.SaveChangesAsyncs())
                {
                    var retorno = await _technologicalAreaPersist.GetAllTechnologicalAreaByIdAsync(technological.id, false);

                    return true;
                }

                return await _geralPersist.SaveChangesAsyncs();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TechnologicalAreaDtos[]> GetAllTechnologicalAreaAsync(bool includeUnidade = false)
        {
            try
            {
                var technological = await _technologicalAreaPersist.GetAllTechnologicalAreaAsync(includeUnidade);
                if( technological == null )return null;

                var resultado = _mapper.Map<TechnologicalAreaDtos[]>(technological);

                return resultado;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TechnologicalAreaDtos[]> GetAllTechnologicalAreaByDescricaoAsync(string descricao, bool includeUnidade = false)
        {
            try
            {
                var technological = await _technologicalAreaPersist.GetAllTechnologicalAreaByDescricaoAsync(descricao,includeUnidade);
                if( technological == null )return null;
               
                var resultado = _mapper.Map<TechnologicalAreaDtos[]>(technological);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  

        public async Task<TechnologicalAreaDtos> GetAllTechnologicalAreaByIdAsync(int id, bool includeUnidade = false)
        {
            try
            {
                var technological = await _technologicalAreaPersist.GetAllTechnologicalAreaByIdAsync(id, includeUnidade);
                if( technological == null)return null;
                
                else
                {
                    var resultado = _mapper.Map<TechnologicalAreaDtos>(technological);
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