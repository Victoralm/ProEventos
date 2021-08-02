import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '@app/models/Evento';

@Injectable({
  providedIn: 'root',
})
export class EventoService {
  baseURL = 'https://localhost:5001/api/Evento';

  // Injetando a classe HttpClient no construtor
  /**
   * @param  {HttpClient} privatehttp
   */
  constructor(private http: HttpClient) {}

  /**
  Encapsulando as chamadas HTTP get em um observable de tipo Evento
   */
  public getEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL);
  }

  public getEventosByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/${tema}/tema`);
  }

  public getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
  }
}
