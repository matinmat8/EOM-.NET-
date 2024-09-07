import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSingerComponent } from './singer-create.component';

describe('SingerCreateComponent', () => {
  let component: AddSingerComponent;
  let fixture: ComponentFixture<AddSingerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddSingerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddSingerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
