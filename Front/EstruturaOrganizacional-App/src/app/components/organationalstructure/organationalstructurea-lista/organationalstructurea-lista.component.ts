import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BusinessArea } from '@app/model/BusinessArea';
import { MarketArea } from '@app/model/MarketArea';
import { OperatingUnit } from '@app/model/OperatingUnit';
import { OrganationalStructure } from '@app/model/OrganationalStructure';
import { TchnologicalArea } from '@app/model/TchnologicalArea';
import { BunissesAreaService } from '@app/services/bunissesArea.service';
import { OrganizationStructureService } from '@app/services/OrganizationStructure.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-organationalstructurea-lista',
  templateUrl: './organationalstructurea-lista.component.html',
  styleUrls: ['./organationalstructurea-lista.component.scss']
})
export class OrganationalstructureaListaComponent implements OnInit {

  modalRef = {} as BsModalRef;
  public organizacao: OrganationalStructure[] = [];
  public organizacaofiltrados: OrganationalStructure[] = [];
  private organizacaoListado = '';
  public organizacaoId = 0;
  public organizacaoIsDeleted = false;
  mercado: MarketArea;
  tecnologia: TchnologicalArea;
  business: BusinessArea;
  operating: OperatingUnit;

  public get filtroLista() {
    return this.organizacaoListado;
  }

  public set filtroLista(value: string){
    this.organizacaoListado = value;
    this.organizacaofiltrados = this.filtroLista ? this.filtrarUnidades(this.filtroLista) : this.organizacao;
  }

  public filtrarUnidades(filtrarPor: string): OrganationalStructure[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.organizacao.filter(
      (organizacao: any) => organizacao.sigla.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      organizacao.ano.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private organizacaoAreaservice: OrganizationStructureService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private businessService: BunissesAreaService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getCarregarOrganizacao();

    this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);
  }

  public getCarregarOrganizacao(): void {
    this.organizacaoAreaservice.getOrganationalStructure().subscribe(
      (organizacaoAreasResp: OrganationalStructure[]) => {
        this.organizacao = organizacaoAreasResp;
        this.organizacaofiltrados = this.organizacao;
        console.log(this.organizacao);
      },
      error => console.log(error)
    );
  }

  openModal(event: any, template: TemplateRef<any>, organizacaoId: number, organizacaoIsDeleted: boolean): void {
    event.stopPropagation();
    this.organizacaoId = organizacaoId;
    this.organizacaoIsDeleted = organizacaoIsDeleted;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    //Modificar a parte de confirmação do delete para que ele seja === e não diferente!
    this.modalRef.hide();
    this.spinner.show();
    this.organizacaoAreaservice.deleteBunisses(this.organizacaoId).subscribe(
      (result: string) => {
        if (result = 'Ok'){
          console.log(result);
          this.toastr.success('A unidade operacional foi deletada com sucesso', 'Deletado');
          this.spinner.hide();
          this.getCarregarOrganizacao();
        }
      },
      (error: any) => {

        this.toastr.error('Erro ao tentar deletar a unidade operacional');
        this.spinner.hide();
        console.error(error);
      },
      () => this.spinner.hide(),
    );
  }

  decline(): void {
    this.modalRef.hide();
  }

  detalheNegocio(id: number): void{
    this.router.navigate([`organizacaoestrutural/detalhe/${id}`]);
  }
}
