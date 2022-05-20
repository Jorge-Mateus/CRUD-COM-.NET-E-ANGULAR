import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-business-area-detalhes',
  templateUrl: './business-area-detalhes.component.html',
  styleUrls: ['./business-area-detalhes.component.scss']
})
export class BusinessAreaDetalhesComponent implements OnInit {

  public form: FormGroup;



  get f(): any{
    return this.form.controls;
  }



  constructor(private fb: FormBuilder) { }


  ngOnInit(): void {
    this.validation();
  }

  public validation() : void{
    this.form = this.fb.group({
      descricao: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(55)]],
      sigla: ['', [Validators.required, Validators.maxLength(10), Validators.minLength(3)]],
      codEMS: ['', [Validators.required, Validators.maxLength(15)]],
    });
  }

  public resetForm(): void{
    this.form.reset();
  }
}
