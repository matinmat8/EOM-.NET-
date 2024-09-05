import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Song } from '../models/song.model';

@Injectable({
  providedIn: 'root'
})
export class SongApiService {

  constructor(private http: HttpClient) { }

  private apiUrl = 'http://localhost:5002/api/Song';


  getData(): Observable<any> {
    const headers = new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Content-Type': 'application/json'
      });
    
    return this.http.get(`${this.apiUrl}`, {headers})

  }

  getDetail(id: number): Observable<Song> {
    const headers = new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Content-Type': 'application/json'
      });

    return this.http.get<Song>(`${this.apiUrl}/${id}`, {headers})
  }

  createSong(song: any): Observable<any> {
    const headers = new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Content-Type': 'application/json'
      });
      
    return this.http.post<any>(`${this.apiUrl}`, song, {headers})
  }

  deleteSong(songId: number): Observable<Song> {
    const headers = new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Content-Type': 'application/json'
      });
    
    return this.http.delete<Song>(`${this.apiUrl}/${songId}`, {headers})
  }
}
