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

    public class OperatingUnitController : ControllerBase
    {
        
        private IOperatingUnitService _operatingUnitsService; 

        public OperatingUnitController(IOperatingUnitService operatingUnitsService)
        {
           _operatingUnitsService = operatingUnitsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var operating = await _operatingUnitsService.GetAllOperatingUnitAsync(true);
                if(operating == null) return NoContent();
                
                return Ok(operating);
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
                var operating = await _operatingUnitsService.GetAllOperatingUnitByIdAsync(id, true);
                if(operating == null) return NoContent(); 
                
                return Ok(operating);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar  area de negocio: {ex.Message}");
            }
        }

        [HttpGet("{sigla}/sigla")]
        public async Task <IActionResult> GetBySigla(string sigla)
        {
             try
            {
                var operating = await _operatingUnitsService.GetAllOperatingUnitBySiglaAsync(sigla, true);
                if(operating == null) return NoContent(); 
                
                return Ok(operating);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar  area de negocio: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(OperatingUnitsDtos model)
        {
            try
            {
                var operating = await _operatingUnitsService.AddOperatingUnit(model);
                    
                if(operating.sigla == "null" || operating.sigla == "" ||
                   operating.descricao == "null" || operating.descricao == "" ||
                   operating.codReduzido == "null" || operating.codReduzido == "")return NotFound("Não pode ser escrito null ou deixar em vazio, preencha corretamente!");         
                if(operating == null) return NoContent(); 

                return Ok(operating);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar adicionar area de negocio: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, OperatingUnitsDtos model)
        {
            try
            {
                var operating = await _operatingUnitsService.UpdateOperatingUnit(id, model);
                if(operating == null) return NoContent();
                return Ok(operating);
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
                var result = await _operatingUnitsService.GetAllOperatingUnitByIdAsync(id);

                if(result != null){
                    result.IsDeleted = true;
                   return await _operatingUnitsService.Delete(id, result)
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