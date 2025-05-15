import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SimulateCdbComponent } from './simulate-cdb.component';

describe('SimulateCdbComponent', () => {
  let component: SimulateCdbComponent;
  let fixture: ComponentFixture<SimulateCdbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SimulateCdbComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SimulateCdbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
