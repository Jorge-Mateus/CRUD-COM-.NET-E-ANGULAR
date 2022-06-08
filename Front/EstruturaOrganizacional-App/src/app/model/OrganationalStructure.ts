import { BusinessArea } from "./BusinessArea";
import { MarketArea } from "./MarketArea";
import { OperatingUnit } from "./OperatingUnit";
import { TchnologicalArea } from "./TchnologicalArea";

export interface OrganationalStructure {

 id: number;
 IsDeleted: boolean;
 ano: number;

 BusinessArea: BusinessArea;
 MarketArea: MarketArea;
 TchnologicalArea: TchnologicalArea;
 OperatingUnit: OperatingUnit;

 BusinessAreaDtosId: number;
 MarketAreaDtosID: number;
 TechnologicalAreaDtosId: number;
 OperatingUnitsDtosId: number;

}
