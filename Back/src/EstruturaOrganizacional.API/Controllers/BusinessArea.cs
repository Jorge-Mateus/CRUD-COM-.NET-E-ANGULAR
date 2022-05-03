using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EstruturaOrganizacional.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessAreaController : ControllerBase
    {     

        public IEnumerable<BusinessArea> _businessarea = new BusinessArea[]
        {
               new BusinessArea(){
                BusinessAreaId = 1,
                Sigla = "cimatec",
                CodReduzido = "105",
               },
               new BusinessArea(){
                BusinessAreaId = 2,
                Sigla = "cimatec park",
                CodReduzido = "106",
               }           
        };
        
        public BusinessAreaController()
        {     
        }

        [HttpGet]
        public IEnumerable<BusinessArea> Get()
        {
           return _businessarea;
        }

        [HttpGet("{id}")]
        public IEnumerable<BusinessArea> GetById(int id)
        {
           return _businessarea.Where(businessarea => businessarea.BusinessAreaId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "exemplo de post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }
        
        [HttpDelete("{id}")]

        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}
