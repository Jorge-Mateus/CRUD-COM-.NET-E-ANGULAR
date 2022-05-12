using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Persistence;
using EstruturaOrganizacional.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EstruturaOrganizacional.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessAreasController : ControllerBase
    {     

        
       private readonly EstruturaOrganizacionalContext _context;

        public BusinessAreasController(EstruturaOrganizacionalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<BusinessArea> Get()
        {
           return _context.BUSINESSAREA;
        }

        [HttpGet("{id}")]
        public BusinessArea GetById(int id)
        {
           return _context.BUSINESSAREA.FirstOrDefault(
               businessAreas => businessAreas.id == id
               );
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

