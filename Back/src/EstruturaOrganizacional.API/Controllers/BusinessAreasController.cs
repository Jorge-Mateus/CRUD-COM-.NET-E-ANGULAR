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
    public class BusinessAreasController : ControllerBase
    {     
        private IBusinessAreaService _businessAreaService;

        public BusinessAreasController(IBusinessAreaService businessAreaService)
        {
            _businessAreaService = businessAreaService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var businessArea = await _businessAreaService.GetAllBusinessAreaAsync(true);
                if(businessArea == null) return NoContent();
                
                return Ok(businessArea);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar  area de negocio: {ex.Message}");
            }
        } 

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById(int id)
        {
             try
            {
                var businessArea = await _businessAreaService.GetAllBusinessAreaByIdAsync(id, true);
                if(businessArea == null) return NoContent(); 
                
                return Ok(businessArea);
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
                var businessArea = await _businessAreaService.GetAllBusinessAreaBySiglaAsync(sigla, true);
                if(businessArea == null) return NoContent(); 
                
                return Ok(businessArea);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar  area de negocio: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(BusinessAreaDto model)
        {
            try
            {
                var businessArea = await _businessAreaService.AddBusinessArea(model);

                if(businessArea.sigla == "null" || businessArea.sigla == "" ||
                   businessArea.descricao == "null" || businessArea.descricao == "" || 
                   businessArea.codEMS == "null" || businessArea.codEMS == "") return NotFound("Não pode ser escrito null ou deixar em vazio, preencha corretamente!");
                
                if(businessArea == null) return NoContent(); 

                return Ok(businessArea);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar adicionar area de negocio: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, BusinessAreaDto model)
        {
            try
            {
                var businessArea = await _businessAreaService.UpdateBusinessArea(id, model);
                if(businessArea == null) return NoContent();
                return Ok(businessArea);
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
                var result = await _businessAreaService.GetAllBusinessAreaByIdAsync(id);

                if(result != null){
                    result.IsDeleted = true;
                   return await _businessAreaService.Delete(id, result)
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

