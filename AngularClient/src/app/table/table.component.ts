import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { kovanice } from '../Models/kovanice.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']

})
export class TableComponent implements OnInit {
  
  dataSources!: MatTableDataSource<kovanice>;
  displayColumns: string[] = ['weight', 'name', 'countryOfOrigin', 'manufactuer', 'price', 'Actions']

  constructor(private apiService: ApiService, public dialog: MatDialog, private _snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.getAllKovanice();
    }


    async getAllKovanice() {
      await this.apiService.getAllKovanice().subscribe((res: kovanice[] | undefined)=>
      {
        this.dataSources = new MatTableDataSource(res);
      });
    }

  }
}