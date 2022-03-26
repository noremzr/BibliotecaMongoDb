import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { DialogData } from "src/interfaces/IDialogData";

@Component({
    selector: 'loan-register-dialog-component',
    templateUrl: 'loan-register-dialog.component.html',
  })
  export class LoanRegisterDialogCompoent {
    constructor(
      public dialogRef: MatDialogRef<LoanRegisterDialogCompoent>,
      @Inject(MAT_DIALOG_DATA) public data: DialogData,
    ) {}

    cancelar(): void {
      this.dialogRef.close();
    }
  }