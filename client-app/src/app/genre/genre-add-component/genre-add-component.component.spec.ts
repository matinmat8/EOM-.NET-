import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenreAddComponentComponent } from './genre-add-component.component';

describe('GenreAddComponentComponent', () => {
  let component: GenreAddComponentComponent;
  let fixture: ComponentFixture<GenreAddComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GenreAddComponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GenreAddComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
