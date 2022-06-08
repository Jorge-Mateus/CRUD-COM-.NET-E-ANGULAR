using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstruturaOrganizacional.Application.Dtos
{
    public class OperatingUnitsDtos
    {
    public virtual int id { get; set; } 
       public virtual string sigla { get; set; }
       public virtual string descricao { get; set; }
       public virtual string codReduzido { get; set; }
       public virtual bool IsDeleted { get; set; }

    //    public List<OrganizationalStructureDtos> Organizacao  { get; set; }

    }
}