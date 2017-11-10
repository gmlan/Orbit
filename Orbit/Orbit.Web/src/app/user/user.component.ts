import { Component, OnInit } from '@angular/core';
import { User } from './User';
import { JsonQueryService } from '../service/json-query.service';
import { Global } from '../shared/global';
import { clone } from 'lodash';
import { JsonResponse } from '../model/JsonResponse';
@Component({
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  Users: User[];

  constructor(private queryService: JsonQueryService) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.queryService.get(Global.BASE_USER_ENDPOINT)
    .subscribe((response:JsonResponse)  => {      
        if (response.Success) {         
          this.Users  = response.Data;
        } else {
          alert(response.Data);
        }
    });
  } 

  removeUser(User: User) {
    if(confirm("Are you sure to delete this user?")){
      this.queryService.delete(Global.BASE_USER_ENDPOINT, User.Id)
      .subscribe((response: JsonResponse)  => {
        if (response.Success) {         
          this.getUsers();
        } else {
          alert(response.Data);
        }
      });
    }
  }
}
