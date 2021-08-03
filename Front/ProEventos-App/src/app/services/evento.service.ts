import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
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
    return this.http.get<Evento[]>(this.baseURL)
    .pipe(take(1));
  }

  public getEventosByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/${tema}/tema`)
    .pipe(take(1));
  }

  public getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseURL}/${id}`)
    .pipe(take(1));
  }

  /** Versão previa
  public postEvento(evento: Evento): Observable<Evento> {
    return this.http.post<Evento>(this.baseURL, evento);
  }

  public putEvento(evento: Evento): Observable<Evento> {
    return this.http.put<Evento>(`${this.baseURL}/${evento.id}`, evento);
  }
  */

  public post(evento: Evento): Observable<Evento> {
    return this.http
      .post<Evento>(this.baseURL, evento)
      .pipe(take(1));
  }

  public put(evento: Evento): Observable<Evento> {
    return this.http
      .put<Evento>(`${this.baseURL}/${evento.id}`, evento)
      .pipe(take(1));
  }

  public deleteEvento(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`)
    .pipe(take(1));
  }
}
