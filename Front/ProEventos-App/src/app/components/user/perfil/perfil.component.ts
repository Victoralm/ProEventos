import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, AbstractControlOptions, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { FieldValidate } from '@app/helpers/FieldValidate';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form!: FormGroup;

  // Conveniente para pegar um FormField apenas com a letra F
  get f(): any { return this.form.controls; }

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
      titulo: ['', Validators.required],
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', Validators.required],
      funcao: ['', Validators.required],
      descricao: ['', Validators.required],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confSenha: ['', Validators.required],
    }, formOptions);
  }

  onSubmit(): void {

    // Vai parar aqui se o form estiver inválido
    if (this.form.invalid) {
      return;
    }
  }

  public FormReset(event: any): void {
    event.preventDefault();
    this.form.reset();
  }

}
