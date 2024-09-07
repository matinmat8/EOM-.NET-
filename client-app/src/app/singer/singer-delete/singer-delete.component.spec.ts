import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingerDeleteComponent } from './singer-delete.component';

describe('SingerDeleteComponent', () => {
  let component: SingerDeleteComponent;
  let fixture: ComponentFixture<SingerDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SingerDeleteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SingerDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
