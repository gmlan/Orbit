import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { JsonQueryService } from './service/json-query.service';
import { HttpModule } from '@angular/http';
import { NgDatepickerModule } from 'ng2-datepicker'; 
import { BsModalModule } from 'ng2-bs3-modal';

import { routing } from './app.routing';

import { AppComponent } from './app.component';
import { IssueComponent } from './issue/issue.component';
import { UserComponent } from './user/user.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { UserdetailsComponent } from './userdetails/userdetails.component';
import { IssuedetailsComponent } from './issuedetails/issuedetails.component';
import { InputComponent } from './control/input/input.component';

@NgModule({
  declarations: [
    AppComponent,
    IssueComponent,
    UserComponent,
    HomeComponent,
    NavComponent,
    UserdetailsComponent,
    IssuedetailsComponent,
    InputComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing,
    NgDatepickerModule, 
    BsModalModule
  ],
  providers: [JsonQueryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
