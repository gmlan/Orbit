import { Component, OnInit,ViewChild } from '@angular/core';
import { JsonQueryService } from '../service/json-query.service';
import { Issue } from './issue';
import { Global } from '../shared/global';
import { clone } from 'lodash';
import { BsModalComponent } from 'ng2-bs3-modal';
import { JsonResponse } from '../model/JsonResponse';
@Component({
  templateUrl: './issue.component.html',
  styleUrls: ['./issue.component.css']
})
export class IssueComponent implements OnInit {
 
  Issues: Issue[];

  @ViewChild('confirmModel')
  confirmModel: BsModalComponent;

  constructor(private queryService: JsonQueryService) { }

  ngOnInit() {
    this.getIssues();
  }

  getIssues() {
    this.queryService.get(Global.BASE_ISSUE_ENDPOINT)
    .subscribe((response: JsonResponse)  => {
        if (response.Success) {         
          this.Issues  = response.Data;
        } else {
          alert(response.Data);
        }
    });
  }
  
  removeIssue(issue: Issue) {
    if(confirm("Are you sure to delete this issue?")){
      this.queryService.delete(Global.BASE_ISSUE_ENDPOINT, issue.Id)
      .subscribe((response:JsonResponse)  => {       
        if (response.Success) {         
          this.getIssues();
        } else {
          alert(response.Data);
        }
      });
    }
  }
}
