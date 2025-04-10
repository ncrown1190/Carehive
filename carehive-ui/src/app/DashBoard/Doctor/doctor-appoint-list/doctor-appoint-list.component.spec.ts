import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorAppointListComponent } from './doctor-appoint-list.component';

describe('DoctorAppointListComponent', () => {
  let component: DoctorAppointListComponent;
  let fixture: ComponentFixture<DoctorAppointListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DoctorAppointListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DoctorAppointListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
