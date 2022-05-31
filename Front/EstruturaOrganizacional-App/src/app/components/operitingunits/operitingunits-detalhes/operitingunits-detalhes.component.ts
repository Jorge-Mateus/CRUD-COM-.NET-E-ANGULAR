import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { OperatingUnit } from '@app/model/OperatingUnit';
import { OperitingUnitsService } from '@app/services/operitingUnits.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-operitingunits-detalhes',
  templateUrl: './operitingunits-detalhes.component.html',
  styleUrls: ['./operitingunits-detalhes.component.scss']
})
export class OperitingunitsDetalhesComponent implements OnInit {

  filial = {} as OperatingUnit;
  public form: FormGroup;
  estadoSalvar = 'post';

  get f(): any{
    return this.form.controls;
  }

  constructor(private fb: FormBuilder,
    private router: ActivatedRoute,
    private operationService: OperitingUnitsService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) { }

    public carregarUnidades(): void {
      const operationIdParam = this.router.snapshot.paramMap.get('id');

      if (operationIdParam != null ){

        this.spinner.show();
        this.estadoSalvar = 'put';

        this.operationService.getOperatingUnitById(+operationIdParam).subscribe({
          next: (operating: OperatingUnit)  =>
          {
            console.log(operating);
            this.filial = {...operating};
            this.form.patchValue(this.filial);
          },
          error: any => {
            this.spinner.hide();
            this.toastr.error('Erro ao tentar carregar unidade operacional', 'Erro!');
            console.error(Error);
          },
          complete: () => this.spinner.hide(),
        });
      }
    }

  public ngOnInit(): void {
      this.validation();
      this.carregarUnidades();
    }

    public validation(): void{
      this.form = this.fb.group({
        descricao: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(55)]],
        sigla: ['', [Validators.required, Validators.maxLength(10), Validators.minLength(3)]],
        codReduzido: ['', [Validators.required, Validators.maxLength(15)]],
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

        this.filial =  (this.estadoSalvar === 'post')
                     ? {...this.form.value}
                     : {id: this.filial.id, ...this.form.value};
        this.operationService[this.estadoSalvar](this.filial).subscribe(
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
