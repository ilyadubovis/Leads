import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LeadListComponent } from './components/lead-list/lead-list.component';
import { LeadDetailsComponent } from './components/lead-details/lead-details.component';

const routes: Routes = [
  { path: '', component: LeadListComponent },
  { path: 'lead-details/:id', component: LeadDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
