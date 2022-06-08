import { OrganationalStructure } from "./OrganationalStructure";

export interface BusinessArea {
      id: number;
      descricao: string;
      sigla: string;
      codEMS: string;
      IsDeleted: boolean;
      Organizacao: OrganationalStructure;
}



