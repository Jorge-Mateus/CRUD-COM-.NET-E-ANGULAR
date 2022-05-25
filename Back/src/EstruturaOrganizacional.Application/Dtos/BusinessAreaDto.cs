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
        
        [Required(ErrorMessage ="O campo {0} é obrigatório o preenchimento"),
         MinLength(3, ErrorMessage ="A {0} deve ter no mínimo 4 caracteres"),
         MaxLength(50, ErrorMessage ="A {0} deve ter no máximo 50 caracteres")]
        public virtual string sigla { get; set; }
        
        [Required(ErrorMessage ="O campo {0} é obrigatório o preenchimento")]
        public virtual string descricao { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório o preenchimento")]
        public virtual string codEMS { get; set; }

        public virtual bool IsDeleted { get; set; }

    }
}