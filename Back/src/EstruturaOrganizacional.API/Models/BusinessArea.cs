using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstruturaOrganizacional.API.Models
{
    public class BusinessArea
    {
        public int BusinessAreaId { get; set; }
        public string Sigla { get; set; }

        public string CodReduzido { get; set; }

    }
}