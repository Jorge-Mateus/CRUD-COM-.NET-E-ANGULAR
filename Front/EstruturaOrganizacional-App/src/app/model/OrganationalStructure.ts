import { BusinessArea } from "./BusinessArea";
import { MarketArea } from "./MarketArea";
import { OperatingUnit } from "./OperatingUnit";
import { TchnologicalArea } from "./TchnologicalArea";

export interface OrganationalStructure {

 id: number;
 ano: Date;
 BusinessArea: BusinessArea[];
 MarketArea: MarketArea[];
 TchnologicalArea: TchnologicalArea[];
 OperatingUnit: OperatingUnit[];
 IsDeleted: boolean;

}
