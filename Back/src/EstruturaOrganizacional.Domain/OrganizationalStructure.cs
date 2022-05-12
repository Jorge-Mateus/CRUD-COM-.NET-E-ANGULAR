using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstruturaOrganizacional.Domain
{
    public class OrganizationalStructure
    {
        public virtual int id { get; set; }
        public virtual DateTime ano { get; set; }
        public virtual int BusinessAreasID { get; set; }
        public virtual IEnumerable <BusinessArea> BusinessArea { get; set; }
        public virtual int MarketAreasId { get; set; }
        public virtual IEnumerable <MarketArea> MarketArea { get; set; }
        public virtual int TchnologicalAreasID { get; set; }
        public virtual IEnumerable <TechnologicalArea> TchnologicalArea { get; set; }
        public virtual int OperatingUnitsID { get; set; }
        public virtual IEnumerable <OperatingUnit> OperatingUnit { get; set; }

    }   

}