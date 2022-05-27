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
    public class TechnologicalAreaController : ControllerBase
    {
        private ITechnologicalAreaService _tecnhologicalAreaService;

        public TechnologicalAreaController(ITechnologicalAreaService tecnhologicalAreaService)
        {
            _tecnhologicalAreaService = tecnhologicalAreaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tecnhological = await _tecnhologicalAreaService.GetAllTechnologicalAreaAsync(true);
                if(tecnhological == null) return NoContent();
                
                return Ok(tecnhological);
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
                var tecnhological = await _tecnhologicalAreaService.GetAllTechnologicalAreaByIdAsync(id, true);
                if(tecnhological == null) return NoContent(); 
                
                return Ok(tecnhological);
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
                var tecnhological = await _tecnhologicalAreaService.GetAllTechnologicalAreaByDescricaoAsync(descricao, true);
                if(tecnhological == null) return NoContent(); 
                
                return Ok(tecnhological);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar  area de negocio: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TechnologicalAreaDtos model)
        {
            try
            {
                var tecnhological = await _tecnhologicalAreaService.AddTechnologicalArea(model);
                
                if(tecnhological == null) return NoContent(); 

                return Ok(tecnhological);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar adicionar area de negocio: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, TechnologicalAreaDtos model)
        {
            try
            {
                var tecnhological = await _tecnhologicalAreaService.UpdateTechnologicalArea(id, model);
                if(tecnhological == null) return NoContent();
                return Ok(tecnhological);
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
                var result = await _tecnhologicalAreaService.GetAllTechnologicalAreaByIdAsync(id);

                if(result != null){
                    result.IsDeleted = true;
                   return await _tecnhologicalAreaService.Delete(id, result)
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