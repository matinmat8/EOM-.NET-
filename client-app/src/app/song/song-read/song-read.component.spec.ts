import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SongReadComponent } from './song-read.component';

describe('SongReadComponent', () => {
  let component: SongReadComponent;
  let fixture: ComponentFixture<SongReadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SongReadComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SongReadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
