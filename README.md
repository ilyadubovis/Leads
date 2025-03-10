# Leads
Leads is an ASP.NET application.
It is built a single Visual Studio project.

## Building blocks
Back-end: .NET8 Web API, SignalR;\
Front-end: Angular17, RxJS, Angular Material.

## Description
**Leads.Server** - ASP.NET Web API service that supports CRUD operations for a lead collection: GET, GET/id, POST, PUT/id, DELETE/id.\
The service uses SignalR to send real-time notifications to the client app on lead collection change.

**Leads.Server.Test** - MS Test project with unit tests for Leads.Server.

See [the detailed API spec](https://github.com/ilyadubovis/Leads/blob/master/Leads.Server/leads.openapi.json)

**Leads.Client** - web-based lead dashboard that displays a list of existing leads and the details for a selected lead.

## Screenshots
![image](https://github.com/user-attachments/assets/0a12b389-34b3-4850-bd5b-832e933bc5dc)
![image](https://github.com/user-attachments/assets/556aefe4-5245-4f4c-8fdf-5eaccc9dec69)
![image](https://github.com/user-attachments/assets/9b7210d2-a824-4e37-9ca6-51427d8346b7)
