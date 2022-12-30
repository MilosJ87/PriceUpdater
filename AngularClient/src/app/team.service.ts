import { _isTestEnvironment } from '@angular/cdk/platform';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
 
  private path = enviroment.apiUrl
  constructor() { }
}
