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
    public class MarketAreaService : IMarketAreaService
    {

        private readonly IGeralPersist _geralPersist;
        private readonly IMarketAreaPersist _marketAreaPersiste;
        private readonly IMapper _mapper;

        public MarketAreaService(IGeralPersist geralPersist,
                                IMarketAreaPersist marketAreaPersiste,
                                IMapper mapper )
        {
            _marketAreaPersiste = marketAreaPersiste;
            _geralPersist = geralPersist;
            _mapper = mapper;
        }

        public async Task<MarketAreaDtos> AddMarketArea(MarketAreaDtos model)
        {
            try
            {   
                var marketare = _mapper.Map<MarketArea>(model);
                _geralPersist.Add<MarketArea>(marketare);
                marketare.IsDeleted = false;

                if (await _geralPersist.SaveChangesAsyncs())
                {
                    var retorno = await _marketAreaPersiste.GetAllMarketAreaByIdAsync(marketare.id, false);//modificar true

                    return _mapper.Map<MarketAreaDtos>(retorno);
                }
                 return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<MarketAreaDtos> UpdateMarketArea(int id, MarketAreaDtos model)
        {
            try
            {
                var marketarea = await _marketAreaPersiste.GetAllMarketAreaByIdAsync(id);
                if(marketarea == null) return null;

                model.id = marketarea.id;

                _mapper.Map(model, marketarea);

                _geralPersist.Update<MarketArea>(marketarea);

                if(await _geralPersist.SaveChangesAsyncs())
                {
                    var retorno = await _marketAreaPersiste.GetAllMarketAreaByIdAsync(marketarea.id, false);

                    return _mapper.Map<MarketAreaDtos>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id, MarketAreaDtos model)
        {
            try{
                var marketarea = await _marketAreaPersiste.GetAllMarketAreaByIdAsync(id);
                if(marketarea == null) return false;

                model.id = marketarea.id;

                _mapper.Map(model, marketarea);

                _geralPersist.Update<MarketArea>(marketarea);

                if(await _geralPersist.SaveChangesAsyncs())
                {
                    var retorno = await _marketAreaPersiste.GetAllMarketAreaByIdAsync(marketarea.id, false);

                    return true;
                }

                return await _geralPersist.SaveChangesAsyncs();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarketAreaDtos[]> GetAllMarketAreaAsync(bool include = false)
        {
            try
            {
                var marketarea = await _marketAreaPersiste.GetAllMarketAreaAsync(include);
                if( marketarea == null )return null;

                var resultado = _mapper.Map<MarketAreaDtos[]>(marketarea);

                return resultado;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarketAreaDtos[]> GetAllMarketAreaByDescricaoAsync(string descricao, bool include = false)
        {
            try
            {
                var marketarea = await _marketAreaPersiste.GetAllMarketAreaByDescricaoAsync(descricao,include);
                if( marketarea == null )return null;
               
                var resultado = _mapper.Map<MarketAreaDtos[]>(marketarea);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarketAreaDtos> GetAllMarketAreaByIdAsync(int id,bool include = false)
        {
            try
            {
                var marketarea = await _marketAreaPersiste.GetAllMarketAreaByIdAsync(id, include);
                if( marketarea == null)return null;
              
                else
                {
                    var resultado = _mapper.Map<MarketAreaDtos>(marketarea);
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