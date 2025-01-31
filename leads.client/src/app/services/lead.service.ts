import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, delay } from 'rxjs';
import { Lead } from '../models/lead';
import { environment } from '../../environments/environment';
import { LeadDetails } from '../models/lead-details';

@Injectable({
  providedIn: 'root'
})
export class LeadService {
  private leadsApiUrl = `${environment.apiUrl}/leads`;

  constructor(private http: HttpClient) { }

  getLeads(delayValue: number = 0): Observable<Lead[]> {
    return this.http.get<Lead[]>(this.leadsApiUrl)
      .pipe(delay(delayValue));
  }

  getLeadById(id: string): Observable<LeadDetails> {
    return this.http.get<LeadDetails>(`${this.leadsApiUrl}/${id}`);
  }
}
