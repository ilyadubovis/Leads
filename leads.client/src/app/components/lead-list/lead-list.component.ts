import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { LeadService } from '../../services/lead.service';
import { Router } from '@angular/router';
import { Lead } from '../../models/lead';
import { map } from 'rxjs';

@Component({
  selector: 'app-lead-list',
  templateUrl: './lead-list.component.html',
  styleUrl: './lead-list.component.css',
})

export class LeadListComponent implements OnInit {
  dataSource!: MatTableDataSource<Lead>;
  displayedColumns = ['name', 'phoneNumber', 'zipCode', 'details'];
  loading = true;
  constructor(private leadService: LeadService, private router: Router) { }
  ngOnInit(): void {
    this.loadLeads();
  }

  loadLeads = () => {
    this.leadService.getLeads().pipe(
      map(leads => this.dataSource = new MatTableDataSource<Lead>(leads)))
      .subscribe({
        next: (data) => {
          console.log(data)
        },
        error: (err) => console.error('Error during lead list request:', err),
        complete: () => { this.loading = false; }
      });
  }

  getLeadDetails = (leadId: string) =>
    this.router.navigate(['/lead-details', leadId]);
}











