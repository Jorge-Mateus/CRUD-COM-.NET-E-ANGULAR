import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MarketArea } from '@app/model/MarketArea';
import { MarketAreaService } from '@app/services/marketArea.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-market-area-detalhes',
  templateUrl: './market-area-detalhes.component.html',
  styleUrls: ['./market-area-detalhes.component.scss']
})
export class MarketAreaDetalhesComponent implements OnInit {

  market = {} as MarketArea;
  public form: FormGroup;
  estadoSalvar = 'post';

  get f(): any{
    return this.form.controls;
  }

  constructor(private fb: FormBuilder,
    private router: ActivatedRoute,
    private marketService: MarketAreaService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) { }


    public carregarMercados(): void {
      const marketIdParam = this.router.snapshot.paramMap.get('id');

      if (marketIdParam != null ){

        this.spinner.show();
        this.estadoSalvar = 'put';

        this.marketService.getMarketAreaById(+marketIdParam).subscribe({
          next: (market: MarketArea)  =>
          {
            console.log(market);
            this.market = {...market};
            this.form.patchValue(this.market);
          },
          error: any => {
            this.spinner.hide();
            this.toastr.error('Erro ao tentar carregar área de mercado', 'Erro!');
            console.error(Error);
          },
          complete: () => this.spinner.hide(),
        });
      }
    }

    ngOnInit(): void {
      this.validation();
      this.carregarMercados();
    }

    public validation(): void {
      this.form = this.fb.group({
        descricao: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(55)]],
      });
    }

    public cssValidador(campoForm: FormControl): any {
      return {'is-invalid': campoForm.errors && campoForm.touched};
    }

    public resetForm(): void{
      this.form.reset();
    }

    public salvarAlteracao(): void{

      this.spinner.show();

      if (this.form.valid){

        this.market =  (this.estadoSalvar === 'post')
                     ? {...this.form.value}
                     : {id: this.market.id, ...this.form.value};
        this.marketService[this.estadoSalvar](this.market).subscribe(
          () => this.toastr.success('Unidade de negócio salvo com Sucesso!', 'Sucesso'),
          (error: any) => {
            console.log(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar unidade de negócio', 'Erro!');
          },
          () => this.spinner.hide()
          );
        }
      }

  }
