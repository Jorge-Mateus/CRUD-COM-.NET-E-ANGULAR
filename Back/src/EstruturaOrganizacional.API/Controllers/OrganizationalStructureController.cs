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
    public class OrganizationalStructureController : ControllerBase
    {     
        private IOrganizationalStructureService _organizationalStructure;

        public OrganizationalStructureController(IOrganizationalStructureService organizationalStructure)
        {
            _organizationalStructure = organizationalStructure;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ornazitional = await _organizationalStructure.GetAllEstruturaOrganizacionalAnoAsync(true);
                if(ornazitional == null) return NoContent();
                
                return Ok(ornazitional);
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
                var ornazitional = await _organizationalStructure.GetAllOrganizationalStructureByIdAsync(id, true);
                if(ornazitional == null) return NoContent(); 
                
                return Ok(ornazitional);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar  area de negocio: {ex.Message}");
            }
        }

        [HttpGet("{ano}/ano")]
        public async Task <IActionResult> GetBySigla(int ano)
        {
             try
            {
                var ornazitional = await _organizationalStructure.GetAllEstruturaOrganizacionalByAnoAsync(ano, true);
                if(ornazitional == null) return NoContent(); 
                
                return Ok(ornazitional);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar  area de negocio: {ex.Message}");
            }
        }

        [HttpPost]
        public  async Task<IActionResult> Post(OrganizationalStructureDtos model)
        {
            try
            {
                var organizacao = await _organizationalStructure.AddOrganization(model);
                
                if(organizacao == null) return NoContent(); 

                return Ok(organizacao);
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar adicionar area de negocio: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, OrganizationalStructureDtos model)
        {
            try
            {
                var ornazitional = await _organizationalStructure.UpdateOrganization(id, model);
                if(ornazitional == null) return NoContent();
                return Ok(ornazitional);
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
                var result = await _organizationalStructure.GetAllOrganizationalStructureByIdAsync(id);

                if(result != null){
                    result.IsDeleted = true;
                   return await _organizationalStructure.Delete(id, result)
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

