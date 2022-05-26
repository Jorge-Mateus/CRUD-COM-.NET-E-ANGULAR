import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BusinessArea } from '@app/model/BusinessArea';
import { BunissesAreaService } from '@app/services/bunissesArea.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-business-area-detalhes',
  templateUrl: './business-area-detalhes.component.html',
  styleUrls: ['./business-area-detalhes.component.scss']
})
export class BusinessAreaDetalhesComponent implements OnInit {

  business = {} as BusinessArea;
  public form: FormGroup;
  estadoSalvar = 'post';

  get f(): any{
    return this.form.controls;
  }
  constructor(private fb: FormBuilder,
    private router: ActivatedRoute,
    private businessService: BunissesAreaService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) { }


    public carregarUnidades(): void {
      const businessIdParam = this.router.snapshot.paramMap.get('id');

      if (businessIdParam != null ){

        this.spinner.show();
        this.estadoSalvar = 'put';

        this.businessService.getBunissesAreaById(+businessIdParam).subscribe({
          next: (business: BusinessArea)  =>
          {
            console.log(business);
            this.business = {...business};
            this.form.patchValue(this.business);
          },
          error: any => {
            this.spinner.hide();
            this.toastr.error('Erro ao tentar carregar unidade', 'Erro!');
            console.error(Error);
          },
          complete: () => this.spinner.hide(),
        });
      }
    }

    ngOnInit(): void {
      this.validation();
      this.carregarUnidades();
    }

    public validation(): void{
      this.form = this.fb.group({
        descricao: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(55)]],
        sigla: ['', [Validators.required, Validators.maxLength(10), Validators.minLength(3)]],
        codEMS: ['', [Validators.required, Validators.maxLength(15)]],
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

        this.business =  (this.estadoSalvar === 'post')
                     ? {...this.form.value}
                     : {id: this.business.id, ...this.form.value};
        //this.business.IsDeleted = false; 
        this.businessService[this.estadoSalvar](this.business).subscribe(
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
