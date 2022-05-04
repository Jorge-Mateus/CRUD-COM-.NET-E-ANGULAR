using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.API.Data;
using EstruturaOrganizacional.API.Data.Migrations;
using EstruturaOrganizacional.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EstruturaOrganizacional.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessAreasController : ControllerBase
    {     

        
       private readonly DataContext _context;

        public BusinessAreasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<BusinessArea> Get()
        {
           return _context.BusinessAreas;
        }

        [HttpGet("{id}")]
        public BusinessArea GetById(int id)
        {
           return _context.BusinessAreas.FirstOrDefault(
               businessAreas => businessAreas.BusinessAreaId == id
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

