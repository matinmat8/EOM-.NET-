import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingerReadComponent } from './singer-read.component';

describe('SingerReadComponent', () => {
  let component: SingerReadComponent;
  let fixture: ComponentFixture<SingerReadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SingerReadComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SingerReadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
