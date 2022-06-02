using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstruturaOrganizacional.Application.Dtos
{
    public class OrganizationalStructureDtos
    {
        public virtual int id { get; set; }
        public virtual int ano { get; set; }
        public virtual BusinessAreaDto BusinessArea { get; set; }
        public virtual MarketAreaDtos MarketArea { get; set; }
        public virtual TechnologicalAreaDtos TchnologicalArea { get; set; }
        public virtual OperatingUnitsDtos OperatingUnit { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}