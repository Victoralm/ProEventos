import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';

import { faCalendarAlt, faEye, faEyeSlash, faPlusCircle, faTrash } from '@fortawesome/free-solid-svg-icons';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {

  // Fonts Awesome
  faCalendarAlt = faCalendarAlt;
  faPlusCircle = faPlusCircle;
  faEye = faEye;
  faEyeSlash = faEyeSlash;
  faTrash = faTrash;
  public faIcon: any[] = [];
  // modalRef: BsModalRef;  // Dá erro: Property 'modalRef' has no initializer and is not definitely assigned in the constructor
  modalRef = {} as BsModalRef;

  public eventos: Evento[] = [];

  // Property binding
  public widthImgSmall: number = 100;
  public marginImgSmall = 2; // Notar que a atribuição de tipo é opcional
  public showImg: boolean = true;
  private _listFilter: string = ''; // Requer a importação de FormsModule (que requer "import { FormsModule } from '@angular/forms';") em "app.module.ts"
  eventosFiltrados: Evento[] = [];



  // Injetando a classe EventoService no construtor
  /**
   * @param  {EventoService} privateeventoService
   */
  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
    ) { }

  /**
   * @returns string
   */
  public get ListFilter(): string {
    return this._listFilter;
  }

  /**
   * @param  {string} value
   */
  public set ListFilter(value: string) {
    this._listFilter = value;
    this.eventosFiltrados = this._listFilter
      ? this.FiltrarEventos(this._listFilter)
      : this.eventos;
  }

  /**
   * @param  {string} filterBy
   * @returns Evento
   */
  public FiltrarEventos(filterBy: string): Evento[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string }) =>
        evento.tema.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  /**
   * @return void
   */
  public ngOnInit(): void {
    this.GetEventos();

    /** spinner starts on init */
    this.spinner.show();

    // setTimeout(() => {
    //   /** spinner ends after 5 seconds */
    //   this.spinner.hide();
    // }, 2000);
  }

  /**
   * @return void
   */
  public toggleImg(): void {
    this.showImg = !this.showImg;
  }

  /**
   * toggleBtnImgAndText
   */
  public toggleBtnImgAndText(): any {
    // let faIcon: string[] = [];
    this.showImg ?
      this.faIcon = [faEye, "Exibir"] :
      this.faIcon = [faEyeSlash, "Ocultar"];
    return this.faIcon;
  }

  // public GetEventos(): void {
  //   this.eventoService.getEventos().subscribe(
  //       (_eventos: Evento[]) => {
  //         this.eventos = _eventos;
  //         this.eventosFiltrados = this.eventos;
  //       },
  //       (error) => console.log(error),
  //   );
  // }

  /**
   * @returns void
   */
  public GetEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide(),
        this.toastr.error(`${error.message}`, 'Error...'),
        console.log(error)
      },
      complete: () => this.spinner.hide(),
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide();
    this.toastr.success('Event deleted successfully!', 'Deleted');
  }

  decline(): void {
    this.modalRef.hide();
  }

  // showSuccess() {
  //   this.toastr.success('Hello world!', 'Toastr fun!');
  // }

  detalheEvento(id: number): void {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }

}
