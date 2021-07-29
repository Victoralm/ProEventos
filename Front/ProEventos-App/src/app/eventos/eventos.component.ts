import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  // Gerando uma nova propriedade (objeto) para o component
  /**
  public eventos: any = [
    {
      Tema: 'Angular 12',
      Local: 'Rio de Janeiro',
    },
    {
      Tema: '.Net 5',
      Local: 'Botafogo',
    },
    {
      Tema: 'Angular e suas novidades',
      Local: 'Tijuca',
    },
  ];
  */
  public eventos: any = [];

  // Property binding
  widthImgSmall: number = 100;
  marginImgSmall = 2; // Notar que a atribuição de tipo é opcional
  showImg: boolean = true;
  private _listFilter: string = ''; // Requer a importação de FormsModule (que requer "import { FormsModule } from '@angular/forms';") em "app.module.ts"
  eventosFiltrados: any = [];

  /**
   * get ListFilter
   */
  public get ListFilter(): string {
    return this._listFilter;
  }
  /**
   * set ListFilter
   */
  public set ListFilter(value: string) {
    this._listFilter = value;
    this.eventosFiltrados = this._listFilter
      ? this.FiltrarEventos(this._listFilter)
      : this.eventos;
  }

  FiltrarEventos(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string }) =>
        evento.tema.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.GetEventos();
  }

  toggleImg() {
    this.showImg = !this.showImg;
  }

  /**
   * GetEventos
   */
  public GetEventos(): void {
    this.http.get('https://localhost:5001/api/Evento').subscribe(
      (response) => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      (error) => console.log(error)
    );

    /**
    this.eventos = [
      {
        Tema: 'Angular 12',
        Local: 'Rio de Janeiro',
      },
      {
        Tema: '.Net 5',
        Local: 'Botafogo',
      },
      {
        Tema: 'Angular e suas novidades',
        Local: 'Tijuca',
      },
    ];
    */
  }
}
