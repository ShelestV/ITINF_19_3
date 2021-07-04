import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AutorizationComponent } from './autorization/autorization.component';
import { FeedComponent } from './feed/feed.component';
import { FriendsComponent } from './friends/friends.component';
import { ProfileComponent } from './profile/profile.component';
import { RegistrationComponent } from './registration/registration.component';
import { SearchComponent } from './search/search.component';

const routes: Routes = [
  {path:'Autorization', component:AutorizationComponent},
  {path:'Registration', component:RegistrationComponent},
  {path:'Feed', component:FeedComponent},
  {path:'Profile', component:ProfileComponent},
  {path:'Friends', component:FriendsComponent},
  {path:'Search', component:SearchComponent},
  {path:'Feed/Profile', component:ProfileComponent},
  {path:'Friends/Profile', component:ProfileComponent},
  {path:'Search/Profile', component:ProfileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
