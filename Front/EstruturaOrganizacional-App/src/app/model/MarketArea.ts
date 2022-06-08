import { OrganationalStructure } from "./OrganationalStructure";

export interface MarketArea {

  id: number;
  descricao: string;
  IsDeleted: boolean;
  Organizacao: OrganationalStructure;
}
