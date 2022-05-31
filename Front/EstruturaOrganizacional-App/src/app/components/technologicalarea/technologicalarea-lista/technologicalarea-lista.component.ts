import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { TchnologicalArea } from '@app/model/TchnologicalArea';
import { TechnologicalAreaService } from '@app/services/technologicalArea.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-technologicalarea-lista',
  templateUrl: './technologicalarea-lista.component.html',
  styleUrls: ['./technologicalarea-lista.component.scss']
})
export class TechnologicalareaListaComponent implements OnInit {

  modalRef = {} as BsModalRef;
  public tecnoligias: TchnologicalArea[] = [];
  public tecnoligiasfiltrados: TchnologicalArea[] = [];
  private filtroListado = '';
  public tecnoligiasId = 0;
  public tecnoligiaIsDeleted = false;

  public get filtroLista() {
    return this.filtroListado;
  }

  public set filtroLista(value: string){
    this.filtroListado = value;
    this.tecnoligiasfiltrados = this.filtroLista ? this.filtrarUnidades(this.filtroLista) : this.tecnoligias;
  }

  public filtrarUnidades(filtrarPor: string): TchnologicalArea[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.tecnoligias.filter(
      (tecnoligias: any) => tecnoligias.descricao.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      tecnoligias.descricao.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private tecnologiaAreaservice: TechnologicalAreaService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getCarregarAreaTecnologica();

    this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);
  }

  public getCarregarAreaTecnologica(): void {
    this.tecnologiaAreaservice.GetTechnologicalArea().subscribe(
      (tecnologiaResp: TchnologicalArea[]) => {
        this.tecnoligias = tecnologiaResp;
        this.tecnoligiasfiltrados = this.tecnoligias;
      },
      error => console.log(error)
    );
  }

  openModal(event: any, template: TemplateRef<any>, tecnoligiasId: number, tecnoligiaIsDeleted: boolean): void {
    event.stopPropagation();
    this.tecnoligiasId = tecnoligiasId;
    this.tecnoligiaIsDeleted = tecnoligiaIsDeleted;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    //Modificar a parte de confirmação do delete para que ele seja === e não diferente!
    this.modalRef.hide();
    this.spinner.show();
    this.tecnologiaAreaservice.deleteTchnological(this.tecnoligiasId).subscribe(
      (result: string) => {
        if (result = 'Ok'){
          console.log(result);
          this.toastr.success('A unidade operacional foi deletada com sucesso', 'Deletado');
          this.spinner.hide();
          this.getCarregarAreaTecnologica();
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
    this.router.navigate([`areatecnologica/detalhe/${id}`]);
  }


}
