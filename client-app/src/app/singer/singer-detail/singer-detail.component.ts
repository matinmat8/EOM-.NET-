import { Component, OnInit } from '@angular/core';
import { SingerApiService } from '../singer-api.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Singer } from '../../models/singer.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-singer-detail',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterLink],
  templateUrl: './singer-detail.component.html',
  styleUrl: './singer-detail.component.css'
})
export class SingerDetailComponent implements OnInit {

  singer: Singer = {
    id: 0, name: '', about_singer:'', GenreId: 0, AlbumId: 0 
  };


  constructor(
    private singerApiService:SingerApiService,
    private route: ActivatedRoute
  ) {}


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const singerId = +params['id'];
      this.singerApiService.getDetail(singerId).subscribe(data => {
        this.singer = data;
      })
    })
  }
}
