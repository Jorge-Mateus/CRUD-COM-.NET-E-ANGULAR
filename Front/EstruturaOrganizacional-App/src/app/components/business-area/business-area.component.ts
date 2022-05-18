import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BusinessArea } from 'src/app/model/BusinessArea';
import { BunissesAreaService } from 'src/app/services/bunissesArea.service';



@Component({
  selector: 'app-business-area',
  templateUrl: './business-area.component.html',
  styleUrls: ['./business-area.component.scss']
})
export class BusinessAreaComponent implements OnInit {

  modalRef = {} as BsModalRef;
  public businessareas: BusinessArea[] = [];
  public businessareasfiltrados: BusinessArea[] = [];
  private filtroListado = '';

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
      businessarea.codReduzido.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private bunissesAreaservice: BunissesAreaService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) { }

  public ngOnInit(): void {
    this.getBusinessArea();

    this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);
  }

  public getBusinessArea(): void {
    this.bunissesAreaservice.getBunissesArea().subscribe(
      (businessAreasResp: BusinessArea[]) => {
        this.businessareas = businessAreasResp;
        this.businessareasfiltrados = this.businessareas;
      },
      error => console.log(error)
    );
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.toastr.success('A unidade operacional foi deletada com sucesso', 'Deletado');
    this.modalRef.hide();

  }

  decline(): void {
    this.modalRef.hide();
  }

}
