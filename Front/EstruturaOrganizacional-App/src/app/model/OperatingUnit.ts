import { OrganationalStructure } from "./OrganationalStructure";

export interface OperatingUnit {
   id: number;
   sigla: string;
   descricao: string;
   codReduzido: string;
   IsDeleted: boolean;
   Organizacao: OrganationalStructure;
}
