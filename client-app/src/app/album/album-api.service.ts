import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Album } from '../models/album.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AlbumApiService {

  private apiUrl = 'http://localhost:5002/api/Album';

  constructor(private http: HttpClient) { }

  
  getAlbum(id: number): Observable<any> {
    const headers = new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Content-Type': 'application/json'
      });
    return this.http.get(`${this.apiUrl}/${id}`) 
  }

  addAlbum(album: Album): Observable<Album> {
    const headers = new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Content-Type': 'application/json'
      });
    return this.http.post<Album>(`${this.apiUrl}`, album, {headers})
  }

}
