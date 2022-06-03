using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaOrganizacional.Domain;
using System.ComponentModel.DataAnnotations;

namespace EstruturaOrganizacional.Application.Dtos
{
    public class OrganizationalStructureDtos
    {
        public virtual int id { get; set; }
        public virtual int ano { get; set; }
        
        public int BusinessAreaDtosId { get; set; }
        public virtual BusinessAreaDto BusinessArea { get; set; }

        public int MarketAreaDtosID { get; set; }
        public virtual MarketAreaDtos MarketArea { get; set; }

        public int TechnologicalAreaDtosId { get; set; }
        public virtual TechnologicalAreaDtos TchnologicalArea { get; set; }
        
        public int OperatingUnitsDtosId { get; set; }
        public virtual OperatingUnitsDtos OperatingUnit { get; set; }
        

        public virtual bool IsDeleted { get; set; }

            }
}