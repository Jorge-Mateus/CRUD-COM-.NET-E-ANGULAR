import { BusinessArea } from "./BusinessArea";
import { MarketArea } from "./MarketArea";
import { OperatingUnit } from "./OperatingUnit";
import { TchnologicalArea } from "./TchnologicalArea";

export interface OrganationalStructure {

 id: number;
 ano: number;

 BusinessArea: BusinessArea;
 BusinessAreaDtosId: number;

 MarketArea: MarketArea;
 MarketAreaDtosID: number;

 TchnologicalArea: TchnologicalArea;
 TechnologicalAreaDtosId: number;

 OperatingUnit: OperatingUnit;
 OperatingUnitsDtosId: number;


 IsDeleted: boolean;


}
