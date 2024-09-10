import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Song } from '../models/song.model';
import { CreateSongDto } from '../dtos/CreateSongDto.model';
import { UpdateSongDto } from '../dtos/UpdateSongDto.model';

@Injectable({
  providedIn: 'root'
})
export class SongApiService {

  constructor(private http: HttpClient) { }

  private apiUrl = 'http://localhost:5002/api/Song';


  getData(): Observable<any> {
    
    return this.http.get(`${this.apiUrl}`)

  }

  getDetail(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`)
  }

  createSong(songData: FormData): Observable<any> {
    return this.http.post<any>(this.apiUrl, songData);
  }


  addSongWithSingers(createSongDto: CreateSongDto): Observable<CreateSongDto> {
    return this.http.post<CreateSongDto>(this.apiUrl, createSongDto);

}

  deleteSong(songId: number): Observable<Song> {
    
    return this.http.delete<Song>(`${this.apiUrl}/${songId}`)
  }

  updateSong(updateSongDto: UpdateSongDto): Observable<UpdateSongDto> {
    
    return this.http.put<UpdateSongDto>(`${this.apiUrl}`, updateSongDto)
  }
}
