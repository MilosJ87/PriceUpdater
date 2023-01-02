import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MaterialModule } from '../material/material.module';

@Component({
  selector: 'app-delete-country',
  standalone: true,
  imports:[CommonModule, MaterialModule],
  templateUrl: './delete-country.component.html',
  styleUrls: ['./delete-country.component.css']
})

export class DeleteCountryComponent {

  constructor(public dialogRef: MatDialogRef<DeleteCountryComponent>)
  {

  }

  delete()
  {
    this.dialogRef.close(true);
  }
  close()
  {
    this.dialogRef.close(false);
  }

}
