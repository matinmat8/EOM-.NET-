import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateSingerDto } from '../dtos/CreateSingerDto.modl';
import { Observable } from 'rxjs';
import { Singer } from '../models/singer.model';
import { UpdateSingerDto } from '../dtos/UpdateSingerDto.model';

@Injectable({
  providedIn: 'root'
})
export class SingerApiService {

  private apiUrl = "http://localhost:5002/api/Singer"

  constructor(private http: HttpClient) { }


  getSingers(): Observable<Singer[]> {
    return this.http.get<Singer[]>(`${this.apiUrl}`)
  }


  getDetail(singerId: number): Observable<Singer> {
    return this.http.get<Singer>(`${this.apiUrl}/${singerId}`)
  }


  addSinger(signer: CreateSingerDto): Observable<CreateSingerDto> {
    return this.http.post<CreateSingerDto>(this.apiUrl, signer)
  }

  deleteSinger(singerId: number): Observable<Singer> {

    return this.http.delete<Singer>(`${this.apiUrl}/${singerId}`)
  }


  updateSinger(updateSingerDto: UpdateSingerDto): Observable<UpdateSingerDto> {
    return this.http.put<UpdateSingerDto>(`${this.apiUrl}`, updateSingerDto)
  }
}
