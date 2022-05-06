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
        public int BusinessAreasID { get; set; }
        public BusinessArea BusinessArea { get; set; }
        public int MarketAreasId { get; set; }
        public MarketArea MarketArea { get; set; }
        public int TchnologicalAreasID { get; set; }
        public TechnologicalArea TchnologicalArea { get; set; }
        public int OperatingUnitsID { get; set; }
        public OperatingUnit OperatingUnit { get; set; }

    }   

}