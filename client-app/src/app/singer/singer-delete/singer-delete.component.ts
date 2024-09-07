import { Component, OnInit } from '@angular/core';
import { SingerApiService } from '../singer-api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-singer-delete',
  standalone: true,
  imports: [],
  templateUrl: './singer-delete.component.html',
  styleUrl: './singer-delete.component.css'
})
export class SingerDeleteComponent implements OnInit {


  constructor (
    private singerApiService: SingerApiService,
    private route: ActivatedRoute
  ) {}


  ngOnInit(): void {
     this.route.params.subscribe(params => {
      const singerId = +params["id"];
      this.singerApiService.deleteSinger(singerId).subscribe(respone => {
        console.log("Singer Got Deleted", respone)
      })
     }) 
  }
}
