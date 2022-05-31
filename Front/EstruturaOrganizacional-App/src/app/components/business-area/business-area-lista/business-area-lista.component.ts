import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BusinessArea } from 'src/app/model/BusinessArea';
import { BunissesAreaService } from 'src/app/services/bunissesArea.service';

@Component({
  selector: 'app-business-area-lista',
  templateUrl: './business-area-lista.component.html',
  styleUrls: ['./business-area-lista.component.scss']
})
export class BusinessAreaListaComponent implements OnInit {

  modalRef = {} as BsModalRef;
  public businessareas: BusinessArea[] = [];
  public businessareasfiltrados: BusinessArea[] = [];
  private filtroListado = '';
  public businessareasId = 0;
  public businessareaIsDeleted = false;

  public get filtroLista() {
    return this.filtroListado;
  }

  public set filtroLista(value: string){
    this.filtroListado = value;
    this.businessareasfiltrados = this.filtroLista ? this.filtrarUnidades(this.filtroLista) : this.businessareas;
  }

  public filtrarUnidades(filtrarPor: string): BusinessArea[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.businessareas.filter(
      (businessarea: any) => businessarea.sigla.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      businessarea.codEMS.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private bunissesAreaservice: BunissesAreaService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
    ) { }

  public ngOnInit(): void {
    this.getCarregarBusinessArea();

    this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);
  }

  public getCarregarBusinessArea(): void {
    this.bunissesAreaservice.getBunissesArea().subscribe(
      (businessAreasResp: BusinessArea[]) => {
        this.businessareas = businessAreasResp;
        this.businessareasfiltrados = this.businessareas;
      },
      error => console.log(error)
    );
  }

  openModal(event: any, template: TemplateRef<any>, businessareasId: number, businessareaIsDeleted: boolean): void {
    event.stopPropagation();
    this.businessareasId = businessareasId;
    this.businessareaIsDeleted = businessareaIsDeleted;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }



  confirm(): void {
    //Modificar a parte de confirmação do delete para que ele seja === e não diferente!
    this.modalRef.hide();
    this.spinner.show();
    this.bunissesAreaservice.deleteBunisses(this.businessareasId).subscribe(
      (result: string) => {
        if (result = 'Ok'){
          console.log(result);
          this.toastr.success('A unidade operacional foi deletada com sucesso', 'Deletado');
          this.spinner.hide();
          this.getCarregarBusinessArea();
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
    this.router.navigate([`unidadedenegocio/detalhe/${id}`]);
  }

}
