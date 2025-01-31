import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Observable, delay } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LeadSignalRService {

  private hubConnection!: signalR.HubConnection;

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.signalRUrl) // SignalR hub URL
      .build();
  }

  startConnection(): Observable<void> {
    if (this.hubConnection.state != signalR.HubConnectionState.Disconnected) {
      return new Observable;
    }
    return new Observable<void>((observer) => {
      this.hubConnection
        .start()
        .then(() => {
          console.log('Connection established with SignalR hub');
          observer.next();
          observer.complete();
        })
        .catch((error) => {
          console.error('Error connecting to SignalR hub:', error);
          observer.error(error);
        });
    })
    .pipe(delay(2000));
  }

  receiveMessage(): Observable<string> {
    return new Observable<string>((observer) => {
      this.hubConnection.on('LeadCreated', (leadId: string) => {
        observer.next(leadId);
      });
      this.hubConnection.on('LeadUpdated', (leadId: string) => {
        observer.next(leadId);
      });
      this.hubConnection.on('LeadDeleted', (leadId: string) => {
        observer.next(leadId);
      });
    });
  }
}
