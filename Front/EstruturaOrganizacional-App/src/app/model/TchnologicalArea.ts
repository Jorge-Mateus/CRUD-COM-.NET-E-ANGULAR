import { OrganationalStructure } from "./OrganationalStructure";

export interface TchnologicalArea {

      id: number;
      descricao: string;
      unidadeVirtual: string;
      IsDeleted: boolean;
      Organizacao: OrganationalStructure;
}
