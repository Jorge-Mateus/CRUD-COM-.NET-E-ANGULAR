import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { OperatingUnit } from '@app/model/OperatingUnit';
import { OperitingUnitsService } from '@app/services/operitingUnits.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-operitingunitsa-lista',
  templateUrl: './operitingunitsa-lista.component.html',
  styleUrls: ['./operitingunitsa-lista.component.scss']
})
export class OperitingunitsaListaComponent implements OnInit {

  modalRef = {} as BsModalRef;
  public filial: OperatingUnit[] = [];
  public operatingfiltrados: OperatingUnit[] = [];
  private filtroListado = '';
  public operatingId = 0;
  public operatingIsDeleted = false;

  public get filtroLista() {
    return this.filtroListado;
  }

  public set filtroLista(value: string){
    this.filtroListado = value;
    this.operatingfiltrados = this.filtroLista ? this.filtrarUnidades(this.filtroLista) : this.filial;
  }

  public filtrarUnidades(filtrarPor: string): OperatingUnit[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.filial.filter(
      (businessarea: any) => businessarea.sigla.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      businessarea.codReduzido.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private operatingAreaservice: OperitingUnitsService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) { }

  public ngOnInit(): void {
    this.getCarregarOperating();

    this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);
  }

  public getCarregarOperating(): void {
    this.operatingAreaservice.getOperatingUnit().subscribe(
      (operatgingAreasResp: OperatingUnit[]) => {
        this.filial = operatgingAreasResp;
        this.operatingfiltrados = this.filial;
      },
      error => console.log(error)
    );
  }
  openModal(event: any, template: TemplateRef<any>, operatingId: number, operatingIsDeleted: boolean): void {
    event.stopPropagation();
    this.operatingId = operatingId;
    this.operatingIsDeleted = operatingIsDeleted;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide();
    this.spinner.show();
    this.operatingAreaservice.deleteOperatingUnits(this.operatingId).subscribe(
      (result: string) => {
        if (result = 'Ok'){
          console.log(result);
          this.toastr.success('A filial foi deletada com sucesso', 'Deletado');
          this.spinner.hide();
          this.getCarregarOperating();
        }
      },
      (error: any) => {

        this.toastr.error('Erro ao tentar deletar a filial');
        this.spinner.hide();
        console.error(error);
      },
      () => this.spinner.hide(),
    );
  }

  decline(): void {
    this.modalRef.hide();
  }

  detalheOperiting(id: number): void{
    this.router.navigate([`filial/detalhe/${id}`]);
  }
}
