import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingerUpdateComponent } from './singer-update.component';

describe('SingerUpdateComponent', () => {
  let component: SingerUpdateComponent;
  let fixture: ComponentFixture<SingerUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SingerUpdateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SingerUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
