import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { SharedService } from './shared.services';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { AutorizationComponent } from './autorization/autorization.component';
import { RegistrationComponent } from './registration/registration.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProfileComponent } from './profile/profile.component';
import { FeedComponent } from './feed/feed.component';
import { FriendsComponent } from './friends/friends.component';
import { SearchComponent } from './search/search.component';
import { ApplicationFriendshipComponent } from './friends/application-friendship/application-friendship.component';
import { ActiveFriendshipComponent } from './friends/active-friendship/active-friendship.component';
import { EditProfileComponent } from './profile/edit-profile/edit-profile.component';
import { AddPostComponent } from './profile/add-post/add-post.component';
import { EditPostComponent } from './feed/edit-post/edit-post.component';
import { CookieService } from 'ngx-cookie-service';

@NgModule({
  declarations: [
    AppComponent,
    AutorizationComponent,
    RegistrationComponent,
    ProfileComponent,
    FeedComponent,
    FriendsComponent,
    SearchComponent,
    ApplicationFriendshipComponent,
    ActiveFriendshipComponent,
    EditProfileComponent,
    AddPostComponent,
    EditPostComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [SharedService, CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
