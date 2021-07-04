import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.services';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  constructor(private service:SharedService) { }

  UserList:any=[];

  UserLoginFilter:string="";
  UserNameFilter:string="";
  UserListWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshUserList();
  }


  refreshUserList() {
    this.service.getUsers().subscribe(data=> {
      this.UserList=data;
      this.UserListWithoutFilter=data;
    });
  }

  FilterFn(){
    var UserLoginFilter = this.UserLoginFilter;
    var UserNameFilter = this.UserNameFilter;

    this.UserList = this.UserListWithoutFilter.filter(function (el:any) {
        return el.USER_LOGIN.toString().toLowerCase().includes(
          UserLoginFilter.toString().trim().toLowerCase()
        )&&
        el.USERNAME.toString().toLowerCase().includes(
          UserNameFilter.toString().trim().toLowerCase()
        )
    });
  }

  sortResult(prop:any,asc:boolean){
    this.UserList = this.UserListWithoutFilter.sort(function(a:any,b:any){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }

  getPath(image:number) {
    return this.service.getImageSource(image);
  }
}
