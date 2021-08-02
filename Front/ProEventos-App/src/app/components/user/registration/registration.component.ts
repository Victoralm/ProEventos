// import { AbstractControlOptions } from '@angular/forms';
import { FormBuilder, FormGroup, Validators, AbstractControlOptions } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { FieldValidate } from '@app/helpers/FieldValidate';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form!: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.FormValidate();
  }

  /**
   * FormValidate
   */
  public FormValidate(): void {

    const formOptions: AbstractControlOptions = {
      validators: FieldValidate.MustMatch('senha', 'confSenha')
    };

    this.form = this.fb.group({
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      userName: ['', Validators.required],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confSenha: ['', Validators.required],
    }, formOptions);
  }

}
