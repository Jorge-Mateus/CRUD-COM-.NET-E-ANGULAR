using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstruturaOrganizacional.Application.Dtos
{
    public class TechnologicalAreaDtos
    {
        public virtual int id { get; set; }
        public virtual string descricao { get; set; }
        public virtual string unidadeVirtual { get; set; } 
        public virtual bool IsDeleted { get; set; }

    //    public List<OrganizationalStructureDtos> Organizacao  { get; set; }
    }
}