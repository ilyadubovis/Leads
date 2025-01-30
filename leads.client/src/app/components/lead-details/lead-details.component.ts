import { Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LeadService } from '../../services/lead.service';
import { LeadDetails } from '../../models/lead-details';
import { Observable, shareReplay } from 'rxjs';

@Component({
  selector: 'app-lead-details',
  templateUrl: './lead-details.component.html',
  styleUrl: './lead-details.component.css'
})
export class LeadDetailsComponent implements OnInit {

  leadDetails: Observable<LeadDetails> | undefined;

  constructor(private route: ActivatedRoute, private leadService: LeadService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadLead(id);
    }
  }

  loadLead(id: string): void {
    this.leadDetails = this.leadService.getLeadById(id).pipe(shareReplay());
  }
}
