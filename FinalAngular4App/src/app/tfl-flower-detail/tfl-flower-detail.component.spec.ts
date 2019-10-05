import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TflFlowerDetailComponent } from './tfl-flower-detail.component';

describe('TflFlowerDetailComponent', () => {
  let component: TflFlowerDetailComponent;
  let fixture: ComponentFixture<TflFlowerDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TflFlowerDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TflFlowerDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
