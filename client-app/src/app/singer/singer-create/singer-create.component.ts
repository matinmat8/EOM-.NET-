import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { SingerApiService } from '../singer-api.service';
import { CreateSingerDto } from '../../dtos/CreateSingerDto.modl';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { resolve } from 'path';

@Component({
  selector: 'app-singer-create',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, CommonModule, ],
  templateUrl: './singer-create.component.html',
  styleUrl: './singer-create.component.css'
})
export class AddSingerComponent implements OnInit {
  singerForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private singerApiService: SingerApiService,
    private router: Router
    ) {}

  ngOnInit(): void {
    this.singerForm = this.fb.group({
      Name: ['', Validators.required],
      GenreId: ['', Validators.required],
      AlbumId: ['', Validators.required],
      Birth: [''],
      Death: [''],
      AboutSinger: ['']
    });
  }

  onSubmit(): void {
    if (this.singerForm.valid) {
      const createSingerDto: CreateSingerDto = this.singerForm.value;
      this.singerApiService.addSinger(createSingerDto).subscribe(response => {
        console.log('Singer added successfully', response);
        console.log('respone id:', response.Id);
        this.router.navigate(['/singer', response.Id]);
        }
      )
    }
  }
}
