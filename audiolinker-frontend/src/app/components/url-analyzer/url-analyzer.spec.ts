import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrlAnalyzer } from './url-analyzer';

describe('UrlAnalyzer', () => {
  let component: UrlAnalyzer;
  let fixture: ComponentFixture<UrlAnalyzer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UrlAnalyzer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UrlAnalyzer);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
