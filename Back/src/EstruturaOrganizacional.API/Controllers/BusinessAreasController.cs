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
                if(businessArea == null) return NotFound("Nenhuma area de negocio encontrada"); 
                
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
                if(businessArea == null) return NotFound("Nenhuma area de negocio por id encontrada"); 
                
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
                if(businessArea == null) return NotFound("Nenhuma sigla não encontrada"); 
                
                return Ok(businessArea);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar  area de negocio: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(BusinessArea model)
        {
            try
            {
                var businessArea = await _businessAreaService.AddBusinessArea(model);
                if(businessArea == null) return BadRequest("Erro ao adicionar uma unidade de negócio"); 
                
                return Ok(businessArea);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar adicionar area de negocio: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, BusinessArea model)
        {
            try
            {
                var businessArea = await _businessAreaService.UpdateBusinessArea(id, model);
                if(businessArea == null) return BadRequest("Erro ao adicionar uma unidade de negócio"); 
                
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
                if( await _businessAreaService.Delete(id))
                    return Ok("Deletado");
                else
                    return BadRequest("Ara nao deletada!");
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar deletar area de negocio: {ex.Message}");
            }
        }
    }
}

