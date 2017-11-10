import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { IssueComponent } from './issue/issue.component';
import { UserComponent } from './user/user.component';
import { HomeComponent } from './home/home.component';
import { UserdetailsComponent } from './userdetails/userdetails.component';
import { IssuedetailsComponent } from './issuedetails/issuedetails.component';

const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'issue', component: IssueComponent, },
    { path: 'issue/:id', component: IssuedetailsComponent },
    { path: 'user', component: UserComponent },  
    { path: 'user/:id', component: UserdetailsComponent },  
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
