using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstruturaOrganizacional.Domain
{
    public class BusinessArea
    {
        public virtual int id { get; set; }
        public virtual string sigla { get; set; }
        public virtual string descricao { get; set; }
        public virtual string codEMS { get; set; }

    }
}