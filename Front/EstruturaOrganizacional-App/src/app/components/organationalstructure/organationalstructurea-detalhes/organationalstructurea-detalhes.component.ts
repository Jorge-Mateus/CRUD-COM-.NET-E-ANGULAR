import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { OrganationalStructure } from '@app/model/OrganationalStructure';
import { OrganizationStructureService } from '@app/services/OrganizationStructure.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BusinessArea } from '@app/model/BusinessArea';
import { OperatingUnit } from '@app/model/OperatingUnit';
import { TchnologicalArea } from '@app/model/TchnologicalArea';
import { MarketArea } from '@app/model/MarketArea';

import { BunissesAreaService } from '@app/services/bunissesArea.service';
import { OperitingUnitsService } from '@app/services/operitingUnits.service';
import { TechnologicalAreaService } from '@app/services/technologicalArea.service';
import { MarketAreaService } from '@app/services/marketArea.service';



@Component({
  selector: 'app-organationalstructurea-detalhes',
  templateUrl: './organationalstructurea-detalhes.component.html',
  styleUrls: ['./organationalstructurea-detalhes.component.scss']
})
export class OrganationalstructureaDetalhesComponent implements OnInit {

  mercado: MarketArea;
  tecnologia: TchnologicalArea;
  business: BusinessArea;
  operating: OperatingUnit;
  organizacao = {} as OrganationalStructure;
  organizacaoSend = {} as OrganationalStructure;
  public form: FormGroup;
  estadoSalvar = 'post';


  get f(): any{
    return this.form.controls;
  }

  constructor(
    // private organizacao2
    private fb: FormBuilder,
    private router: ActivatedRoute,
    private organizacaoService: OrganizationStructureService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private businessService: BunissesAreaService,
    private operatingService: OperitingUnitsService,
    private tecnologiaService: TechnologicalAreaService,
    private mercadoService: MarketAreaService
  ) { }

  public carregarEstrutura(): void {
    const organizacaoIdParam = this.router.snapshot.paramMap.get('id');

    if (organizacaoIdParam != null ){

      this.spinner.show();
      this.estadoSalvar = 'put';

      this.organizacaoService.getOrganationalStructureById(+organizacaoIdParam).subscribe({
        next: (organizacao: OrganationalStructure)  =>
        {
          console.log(organizacao);
          this.organizacao = {...organizacao};
          this.form.patchValue(this.organizacao);
        },
        error: any => {
          this.spinner.hide();
          this.toastr.error('Erro ao tentar carregar Estrutura Organizacional', 'Erro!');
          console.error(Error);
        },
        complete: () => this.spinner.hide(),
      });
    }
  }

  ngOnInit(): void {
    this.validation();
    this.carregarEstrutura();

    this.businessService.getBunissesArea().subscribe((data: any)=>{
      this.business = data;
    });

    this.operatingService.getOperatingUnit().subscribe((data: any)=>{
      this.operating = data;
    });

    this.tecnologiaService.GetTechnologicalArea().subscribe((data: any)=>{
      this.tecnologia = data;
    });

    this.mercadoService.getMarketArea().subscribe((data: any)=>{
      this.mercado = data;
    });

  }

  public validation(): void{
    this.form = this.fb.group({
      ano: ['', [Validators.required, Validators.maxLength(4)]],
      BusinessArea: ['', [Validators.required]],
      MarketArea: ['', [Validators.required]],
      TchnologicalArea: ['', [Validators.required]],
      OperatingUnit: ['', [Validators.required]],

    });
  }

  public resetForm(): void{
    this.form.reset();
  }

  public cssValidador(campoForm: FormControl): any {
    return {'is-invalid': campoForm.errors && campoForm.touched};
  }

  public salvarAlteracao(): void{


    this.spinner.show();

    if (this.form.valid){

      this.organizacao =  (this.estadoSalvar === 'post')
                   ? {...this.form.value}
                   : {id: this.organizacao.id, ...this.form.value};
      console.log(this.organizacao);
      this.organizacaoSend.id = 0;
      this.organizacaoSend.BusinessArea = this.organizacao.BusinessArea;
      this.organizacaoSend.BusinessAreaDtosId = this.organizacao.BusinessArea.id;
      this.organizacaoSend.MarketArea = this.organizacao.MarketArea;
      this.organizacaoSend.MarketAreaDtosID = this.organizacao.MarketArea.id;
      this.organizacaoSend.TchnologicalArea = this.organizacao.TchnologicalArea;
      this.organizacaoSend.TechnologicalAreaDtosId = this.organizacao.TchnologicalArea.id;
      this.organizacaoSend.OperatingUnit = this.organizacao.OperatingUnit;
      this.organizacaoSend.OperatingUnitsDtosId = this.organizacao.OperatingUnit.id;
      this.organizacaoSend.IsDeleted = false;
      console.log(this.organizacaoSend);

      this.organizacaoService[this.estadoSalvar](this.organizacaoSend).subscribe(
        () => this.toastr.success('Estrutura Organizacional salva com Sucesso!', 'Sucesso'),
        (error: any) => {
          console.log(error);
          this.spinner.hide();
          this.toastr.error('Erro ao salvar Estrutura Organizacional', 'Erro!');
        },
        () => this.spinner.hide()
        );
      }
    }
}
