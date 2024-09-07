import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SingerApiService } from '../singer-api.service';
import { UpdateSingerDto } from '../../dtos/UpdateSingerDto.model';
import { CommonModule } from '@angular/common';



@Component({
  selector: 'app-singer-update',
  templateUrl: './singer-update.component.html',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, CommonModule],
  styleUrls: ['./singer-update.component.css']
})
export class SingerUpdateComponent implements OnInit {
  singerForm!: FormGroup;
  singerId!: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private singerApiService: SingerApiService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.singerId = +this.route.snapshot.paramMap.get('id')!;
    this.singerApiService.getDetail(this.singerId).subscribe({
      next: (singer) => {
        this.singerForm = this.fb.group({
          Id: [singer.id, Validators.required],
          Name: [singer.name, Validators.required],
          GenreId: [singer.GenreId, Validators.required],
          AlbumId: [singer.AlbumId, Validators.required],
          Birth: [singer.birth],
          Death: [singer.death],
          AboutSinger: [singer.about_singer]
        });
      },
      error: (err) => console.error('Error fetching singer details', err)
    });
  }

  onSubmit(): void {
    if (this.singerForm.valid) {
      const updateSingerDto: UpdateSingerDto = this.singerForm.value;
      this.singerApiService.updateSinger(updateSingerDto).subscribe({
        next: (response) => {
          console.log('Singer updated successfully', response);
          this.router.navigate(['/singer', response.Id]);
        },
        error: (err) => console.error('Error updating singer', err)
      });
    }
  }
}
