using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstruturaOrganizacional.Application.Dtos
{
    public class BusinessAreaDto
    {
        public virtual int id { get; set; }
        
        public virtual string descricao { get; set; }
       
        public virtual string sigla { get; set; }

        public virtual string codEMS { get; set; }

        public virtual bool IsDeleted { get; set; }


    }
}