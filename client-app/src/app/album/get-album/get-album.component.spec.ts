import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAlbumComponent } from './get-album.component';

describe('GetAlbumComponent', () => {
  let component: GetAlbumComponent;
  let fixture: ComponentFixture<GetAlbumComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetAlbumComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetAlbumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
