import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';


@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  tableData: any[];

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.apiService.getKovanice().subscribe(data => {
      this.tableData[0] = data;
    });
  }
}