import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationFriendshipComponent } from './application-friendship.component';

describe('ApplicationFriendshipComponent', () => {
  let component: ApplicationFriendshipComponent;
  let fixture: ComponentFixture<ApplicationFriendshipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationFriendshipComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationFriendshipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
