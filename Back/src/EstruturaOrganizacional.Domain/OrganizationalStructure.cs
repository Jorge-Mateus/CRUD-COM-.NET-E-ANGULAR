using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstruturaOrganizacional.Domain
{
    public class OrganizationalStructure
    {
       
        public  int id { get; set; }
        
        public virtual bool IsDeleted { get; set; }

        public virtual int ano { get; set; }
        
        public virtual BusinessArea BusinessAreas { get; set; }

        public virtual MarketArea  MarketAreas{ get; set; }

        public virtual TechnologicalArea TchnologicalAreas { get; set; }

        public virtual OperatingUnit OperatingUnits { get; set; }
    }   

}