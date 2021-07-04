import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveFriendshipComponent } from './active-friendship.component';

describe('ActiveFriendshipComponent', () => {
  let component: ActiveFriendshipComponent;
  let fixture: ComponentFixture<ActiveFriendshipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActiveFriendshipComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActiveFriendshipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
