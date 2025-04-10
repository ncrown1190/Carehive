import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorsIdComponent } from './doctors-id.component';

describe('DoctorsIdComponent', () => {
  let component: DoctorsIdComponent;
  let fixture: ComponentFixture<DoctorsIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DoctorsIdComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DoctorsIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
