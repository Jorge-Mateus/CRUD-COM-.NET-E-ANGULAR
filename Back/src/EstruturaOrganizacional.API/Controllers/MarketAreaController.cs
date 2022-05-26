using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Persistence;
using EstruturaOrganizacional.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EstruturaOrganizacional.Persistence.Contextos;
using EstruturaOrganizacional.Application.Contratos;
using Microsoft.AspNetCore.Http;
using EstruturaOrganizacional.Application.Dtos;

namespace EstruturaOrganizacional.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketAreaController : ControllerBase
    {   
        private IMarketAreaService _marketAreaService;
        
        public MarketAreaController(IMarketAreaService marketAreaService )
        {
            _marketAreaService = marketAreaService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var marketArea = await _marketAreaService.GetAllMarketAreaAsync(true);
                if(marketArea == null) return NoContent();
                
                return Ok(marketArea);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar area de mercado: {ex.Message}");
            }
        } 

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById(int id)
        {
             try
            {
                var marketArea = await _marketAreaService.GetAllMarketAreaByIdAsync(id, true);
                if(marketArea == null) return NoContent(); 
                
                return Ok(marketArea);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar  area de negocio: {ex.Message}");
            }
        }

        [HttpGet("{descricao}/descricao")]
        public async Task <IActionResult> GetByDescricao(string descricao)
        {
             try
            {
                var marketArea = await _marketAreaService.GetAllMarketAreaByDescricaoAsync(descricao, true);
                if(marketArea == null) return NoContent(); 
                
                return Ok(marketArea);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar  area de negocio: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(MarketAreaDtos model)
        {
            try
            {
                var marketArea = await _marketAreaService.AddMarketArea(model);
                
                if(marketArea == null) return NoContent(); 

                return Ok(marketArea);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar adicionar area de negocio: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, MarketAreaDtos model)
        {
            try
            {
                var marketArea = await _marketAreaService.UpdateMarketArea(id, model);
                if(marketArea == null) return NoContent();
                return Ok(marketArea);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar atualizar area de negocio: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _marketAreaService.GetAllMarketAreaByIdAsync(id);

                if(result != null){
                    result.IsDeleted = true;
                   return await _marketAreaService.Delete(id, result)
                            ? Ok(new{message = "Deletado"})
                            : throw new Exception("Ocorreu o erro inesperado ao deletar");
                    
                }

                
                return BadRequest("Área de negócio não encontrada");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar deletar area de negocio: {ex.Message}");
            }
        }
       
    }
}