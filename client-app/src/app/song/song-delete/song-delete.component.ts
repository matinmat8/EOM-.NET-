import { Component, OnInit } from '@angular/core';
import { SongApiService } from '../song-api.service';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-song-delete',
  standalone: true,
  imports: [],
  templateUrl: './song-delete.component.html',
  styleUrl: './song-delete.component.css'
})
export class SongDeleteComponent implements OnInit {


  constructor(
    private songApiService: SongApiService,
    private route: ActivatedRoute

  ) {}


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const songId = +params['id'];
      this.onDelete(songId);
    });
  }

  onDelete(songId: number): void{
    this.songApiService.deleteSong(songId).subscribe(response => {
      console.log(response)
    })
  }
}