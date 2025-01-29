import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Lead } from '../models/lead';
import { environment } from '../../environments/environment'; // Import environment
import { LeadDetails } from '../models/lead-details';

@Injectable({
  providedIn: 'root'
})
export class LeadService {
  private leadsApiUrl = `${environment.apiUrl}/leads`;

  constructor(private http: HttpClient) { }

  getLeads(): Observable<Lead[]> {
    return this.http.get<Lead[]>(this.leadsApiUrl);
  }

  getLeadById(id: string): Observable<LeadDetails> {
    return this.http.get<LeadDetails>(`${this.leadsApiUrl}/${id}`);
  }
}
