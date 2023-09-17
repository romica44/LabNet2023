import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SweetAlertContentComponent } from './sweet-alert-content.component';

describe('SweetAlertContentComponent', () => {
  let component: SweetAlertContentComponent;
  let fixture: ComponentFixture<SweetAlertContentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SweetAlertContentComponent]
    });
    fixture = TestBed.createComponent(SweetAlertContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
