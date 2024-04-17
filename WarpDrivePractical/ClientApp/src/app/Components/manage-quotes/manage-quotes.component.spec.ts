import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageQuotesComponent } from './manage-quotes.component';

describe('ManageQuotesComponent', () => {
  let component: ManageQuotesComponent;
  let fixture: ComponentFixture<ManageQuotesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageQuotesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageQuotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
