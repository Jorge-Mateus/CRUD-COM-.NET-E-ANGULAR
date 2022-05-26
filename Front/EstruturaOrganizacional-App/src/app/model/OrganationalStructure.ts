import { BusinessArea } from "./BusinessArea";
import { MarketArea } from "./MarketArea";
import { OperatingUnit } from "./OperatingUnit";
import { TchnologicalArea } from "./TchnologicalArea";

export interface OrganationalStructure {

 id: number;
 ano: Date;
 BusinessAreasID: number;
 BusinessArea: BusinessArea[];
 MarketAreasId: number;
 MarketArea: MarketArea[];
 TchnologicalAreasID: number;
 TchnologicalArea: TchnologicalArea[];
 OperatingUnitsID: number;
 OperatingUnit: OperatingUnit[];
 IsDeleted: boolean;

}
