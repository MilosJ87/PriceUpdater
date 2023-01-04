import { EnvironmentInjector, Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private path = environment.apiBaseURI;

  constructor(private httpClient: HttpClient) {}

  getAllKovanice(): Observable<any> {
    return this.httpClient.get<any[]>(this.path + "");
  }
}