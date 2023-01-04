import { EnvironmentInjector, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private path = enivironment.apiUrl;

  constructor(private httpClient: HttpClient) {}

  getAllPlayers(): Observable<any> {
    return this.httpClient.get<any[]>(this.path + "/Players/GetPlayers");
  }
}