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
  public eventos: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.GetEventos();
  }

  /**
   * GetEventos
   */
  public GetEventos(): void {
    this.http.get('https://localhost:5001/api/Evento').subscribe(
      (response) => (this.eventos = response),
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
