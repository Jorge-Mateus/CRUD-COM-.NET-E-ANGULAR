import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BusinessAreaListaComponent } from '@app/components/business-area/business-area-lista/business-area-lista.component';
import { MarketArea } from '@app/model/MarketArea';
import { MarketAreaService } from '@app/services/marketArea.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-market-area-lista',
  templateUrl: './market-area-lista.component.html',
  styleUrls: ['./market-area-lista.component.scss']
})
export class MarketAreaListaComponent implements OnInit {

  modalRef = {} as BsModalRef;
  public marketarea: MarketArea[] = [];
  public marketareafiltrados: MarketArea[] = [];
  public filtroListado = '';
  public marketareaId = 0;
  public marketareaIsDeleted = false;

  public get filtroLista() {
    return this.filtroListado;
  }

  public set filtroLista(value: string){
    this.filtroListado = value;
    this.marketareafiltrados = this.filtroLista ? this.filtrarUnidades(this.filtroLista) : this.marketarea;
  }

  public filtrarUnidades(filtrarPor: string): MarketArea[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.marketarea.filter(
      (marketarea: any) => marketarea.descricao.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private marketAreaService: MarketAreaService,
              private modalService: BsModalService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private router: Router) { }

    public ngOnInit(): void {
      this.getCarregarMarketArea();

      this.spinner.show();

      setTimeout(() => {
        /** spinner ends after 5 seconds */
        this.spinner.hide();
      }, 5000);
  }


  public getCarregarMarketArea(): void {
    this.marketAreaService.getMarketArea().subscribe(
      (marketAreasResp: MarketArea[]) => {
        this.marketarea = marketAreasResp;
        this.marketareafiltrados = this.marketarea;
      },
      error => console.log(error)
    );
  }

  openModal(event: any, template: TemplateRef<any>, marketareaId: number, marketareaIsDeleted: boolean): void {
    event.stopPropagation();
    this.marketareaId = marketareaId;
    this.marketareaIsDeleted = marketareaIsDeleted;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide();
    this.spinner.show();
    this.marketAreaService.deleteMarket(this.marketareaId).subscribe(
      (result: string) => {
        if (result = 'Ok'){
          console.log(result);
          this.toastr.success('A area de mercado foi deletada com sucesso', 'Deletado');
          this.spinner.hide();
          this.getCarregarMarketArea();
        }
      },
      (error: any) => {

        this.toastr.error('Erro ao tentar deletar a area de mercado');
        this.spinner.hide();
        console.error(error);
      },
      () => this.spinner.hide(),
    );
  }

  decline(): void {
    this.modalRef.hide();
  }

  detalheMarket(id: number): void{
    this.router.navigate([`areademercado/detalhe/${id}`]);
  }
}
