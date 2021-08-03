import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

import { EventoService } from '@app/services/evento.service';
import { Evento } from '@app/models/Evento';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent implements OnInit {

  // evento: Evento;
  evento = {} as Evento; // Mesmo q o anterior, mas ñ enche o saco com erro de inicialização
  // form: FormGroup = new FormGroup({});
  form!: FormGroup;
  estadoSalvar: string = 'post';
  // putState: boolean = false;

  get f(): any {
    return this.form.controls;
  }

  get bsCongig(): any {
    return {
      isAnimated: true,
      adaptivePosition: true,
      containerClass: 'theme-dark-blue',
      dateInputFormat: 'DD/MM/YYYY hh:mm a',
      showWeekNumbers: false
    }
  }

  constructor(private fb: FormBuilder,
              private localeService: BsLocaleService,
              private router: ActivatedRoute,
              private eventoService: EventoService,
              private spinner: NgxSpinnerService,
              private toastr: ToastrService
  )
  {
    this.localeService.use('pt-br');
  }

  ngOnInit(): void {
    this.CarregarEvento();
    this.FormValidate();
  }

  /**
   * CarregarEvento
   */
  public CarregarEvento(): void {
    const eventoIdParam = this.router.snapshot.paramMap.get('id');

    if (eventoIdParam != null) {
      this.spinner.show();
      this.estadoSalvar = 'put';
      // this.putState = true;
      this.eventoService.getEventoById(+eventoIdParam).subscribe({
        next: (evento: Evento) => {
          // this.evento = Object.assign({}, evento);
          this.evento = {... evento}; // Mesmo q o anterior
          this.form.patchValue(this.evento);
        },
        error: (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao tentar carregar o evento.', 'Erro!');
          console.error(error);
        },
        complete: () => this.spinner.hide(),
      });
    }
  }

  /**
   * FormValidate
   */
  public FormValidate(): void {
    this.form = this.fb.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)] ],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)] ],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email] ],
      imagemURL: ['', Validators.required],
    });
  }

  public FormReset(): void {
    this.form.reset();
  }

  public cssValidator(campoForm: FormControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched };
  }


  public salvarAlteracao(): void {
    this.spinner.show();
    if (this.form.valid) {
      // if (!this.putState) {
      if (this.estadoSalvar == 'post') {
        // Usando Spread Operator para passar os valores do form para o campo evento
        this.evento = { ... this.form.value };
        // this.eventoService.postEvento(this.evento).subscribe({
        this.eventoService['post'](this.evento).subscribe({
        next: () => {
          this.toastr.success('Evento salvo com sucesso.', 'Sucesso!')
        },
        error: (error: any) => {
          console.error(error),
          this.toastr.error('Erro ao salvar evento...', 'Erro!')
        }
      }).add(() => this.spinner.hide());
      } else {
        // Usando Spread Operator para passar os valores do form para o campo evento
        this.evento = {id: this.evento.id, ... this.form.value };
        this.eventoService['put'](this.evento).subscribe({
          next: () => {
            this.toastr.success('Evento salvo com sucesso.', 'Sucesso!')
          },
          error: (error: any) => {
            console.error(error),
            this.toastr.error('Erro ao salvar evento...', 'Erro!')
          }
        }).add(() => this.spinner.hide());
      }
    }
  }

  /**
   * Not work...
  public salvarAlteracao(): void {
    this.spinner.show();
    if (this.form.valid) {

      this.evento = (this.estadoSalvar === 'post')
                ? {...this.form.value}
                : {id: this.evento.id, ...this.form.value};

      this.eventoService[`${this.estadoSalvar}`](this.evento).subscribe(
        () => this.toastr.success('Evento salvo com Sucesso!', 'Sucesso'),
        (error: any) => {
          console.error(error);
          this.spinner.hide();
          this.toastr.error('Error ao salvar evento', 'Erro');
        },
        () => this.spinner.hide()
      );
    }
  }
  */

}
