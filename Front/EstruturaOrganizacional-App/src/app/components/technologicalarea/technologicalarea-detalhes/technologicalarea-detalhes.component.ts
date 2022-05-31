import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { TchnologicalArea } from '@app/model/TchnologicalArea';
import { TechnologicalAreaService } from '@app/services/technologicalArea.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-technologicalarea-detalhes',
  templateUrl: './technologicalarea-detalhes.component.html',
  styleUrls: ['./technologicalarea-detalhes.component.scss']
})
export class TechnologicalareaDetalhesComponent implements OnInit {

  technological = {} as TchnologicalArea;
  public form: FormGroup;
  estadoSalvar = 'post';

  get f(): any{
    return this.form.controls;
  }


  constructor(private fb: FormBuilder,
    private router: ActivatedRoute,
    private tecnologiaService: TechnologicalAreaService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) { }

    public carregarUnidades(): void {
      const businessIdParam = this.router.snapshot.paramMap.get('id');

      if (businessIdParam != null ){

        this.spinner.show();
        this.estadoSalvar = 'put';

        this.tecnologiaService.GetTechnologicalAreaById(+businessIdParam).subscribe({
          next: (technological: TchnologicalArea)  =>
          {
            console.log(technological);
            this.technological = {...technological};
            this.form.patchValue(this.technological);
          },
          error: any => {
            this.spinner.hide();
            this.toastr.error('Erro ao tentar carregar area tecnologica', 'Erro!');
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
      unidadeVirtual: ['', [Validators.required, Validators.maxLength(10), Validators.minLength(3)]],
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

      this.technological =  (this.estadoSalvar === 'post')
                   ? {...this.form.value}
                   : {id: this.technological.id, ...this.form.value};
      this.tecnologiaService[this.estadoSalvar](this.technological).subscribe(
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
