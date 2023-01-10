import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { kovanice } from '../Models/kovanice.model';
import { MatTableDataSource,MatTable } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatLabel } from '@angular/material/form-field';
import { poluge } from '../Models/poluge.model';


@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  
  dataSource: MatTableDataSource<poluge>;
  dataSources: MatTableDataSource<kovanice>;
  displayColumns: string[] = ['weight', 'name', 'countryOfOrigin', 'manufactuer', 'price'];

  constructor(private apiService: ApiService, public dialog: MatDialog, private _snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.getAllKovanice();
    }


  async getAllKovanice() {
    console.log('this gets the players from db')
    await this.apiService.getAllKovanice().subscribe((res: kovanice[] | undefined) =>
      {
        this.dataSources = new MatTableDataSource(res);
      });
    }

    async getAllPoluge() {
      await this.apiService.getAllPoluge().subscribe((res: poluge [] | undefined) =>
      {
        this.dataSource = new MatTableDataSource(res);
      });
    }

  }
