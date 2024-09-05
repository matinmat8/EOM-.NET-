import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Genre } from '../models/genre.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenreServiceService {
  private apiUrl = 'http://localhost:5002/api/Genre';

  constructor(private http: HttpClient) { }

  addGenre(genre: Genre): Observable<Genre> {
    // const headers = new HttpHeaders({
    //   'Content-Type': 'application/json',
    //   'Access-Control-Allow-Origin': '*'
    // });
    const headers = new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Content-Type': 'application/json'
    });
    // const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Genre>(`${this.apiUrl}`, genre, {headers})
  }
}
