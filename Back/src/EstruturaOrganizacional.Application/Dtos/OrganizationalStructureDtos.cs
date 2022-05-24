using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstruturaOrganizacional.Application.Dtos
{
    public class OrganizationalStructureDtos
    {
        public virtual int id { get; set; }
        public virtual DateTime ano { get; set; }
        public virtual int BusinessAreasID { get; set; }
        public virtual IEnumerable <BusinessAreaDto> BusinessArea { get; set; }
        public virtual int MarketAreasId { get; set; }
        public virtual IEnumerable <MarketAreaDtos> MarketArea { get; set; }
        public virtual int TchnologicalAreasID { get; set; }
        public virtual IEnumerable <TechnologicalAreaDtos> TchnologicalArea { get; set; }
        public virtual int OperatingUnitsID { get; set; }
        public virtual IEnumerable <OperatingUnitsDtos> OperatingUnit { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}