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

        public int BusinessAreaId { get; set; }
        
        public int MarketAreaID { get; set; }
        
        public int TechnologicalAreaId { get; set; }
       
        public int OperatingUnitsId { get; set; }
       
    
    }   

}