import { Component, OnInit } from '@angular/core';
import { Permisos } from './models/permisos';
import { PermissionService } from './services/permission.services';
import { CommondParent } from './parents/commond-parent';
import { ComponentParent } from './parents/component-parents';
import { DatePipe, Location } from '@angular/common';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent extends ComponentParent implements OnInit {
  idIdentifier: number | undefined;
  nameEmployee?: string;
  lastNameEmployee?: string;  
  typePermission: number | undefined;
  datePermission: Date;
  datePerm: string;
  permissionsList: any = [];
  dataset: any = [];
  isNewMaster: boolean = true;
  disableTextbox = true;
  today = new Date().toJSON().split('T')[0];
  //angForm: FormGroup;

  constructor(private permissionService: PermissionService,
    private formBuilder: FormBuilder,
    private router: Router,
    private location: Location
  ) {
    super();    
    this.datePermission = new Date();   
    this.datePerm = "";     
    this.createForm();         
  }

  createForm() {
    /*this.angForm = this.formBuilder.group({
       name: ['', Validators.required ],
       address: ['', Validators.required ]
    });*/
  }

  ngOnInit() {    
    this.CleanData();
    this.InitAutocomplete();
  }

  ValResult(data: any, error: any) {
    if (data != "" && data != null) {
      this.isNewMaster = false;
      this.alertOk(data, 'User');       
    } else if(error != "" && error != null){
      this.alertError('Error in data', 'Error');
    } else {
      //this.errorHandled(data['message']);
    }
  }

  InitAutocomplete() {
    this.permissionService.GetList().subscribe(
      data => {
        if (data) {
          this.permissionsList = data;
          console.log(this.permissionsList)
        }
      });
  }

  selectedPermission: Permisos = new Permisos();

  addOrEdit() {
    if (this.selectedPermission.idIdentifier === 0) {
      this.selectedPermission.idIdentifier = this.permissionsList.length + 1;
      this.permissionsList.push(this.selectedPermission);
    }

    this.selectedPermission = new Permisos();
  }

  Save() {
    if (confirm('Are you sure you want to save it?')) {
      const params = {
        //idIdentifier: this.idIdentifier,
        NombreEmpleado: this.nameEmployee,
        ApellidoEmpleado: this.lastNameEmployee,        
        TipoPermiso: this.typePermission,
        FechaPermiso: this.datePerm
      };
      debugger      
      if (this.isNewMaster) {        
        this.permissionService.Insert(params)
        .subscribe({
          next: (data: any) => {
            this.ValResult(data, null);
            this.ngOnInit();
          },
          error: (response : any) => {
            this.ValResult(null,response);            
            console.log(response.error);
          }
        });        
      } else {
        this.permissionService.Update(params)
        .subscribe({
          next: (data: any) => {
            this.ValResult(data, null);
            this.ngOnInit();
          },
          error: (response : any) => {
            this.ValResult(null,response);            
            console.log(response.error);
          }
        });
      }
    }
  }

  openForEdit(permission: Permisos) {
    this.isNewMaster = false;
    const datePipe = new DatePipe('en-US')
    const formattedDate = datePipe.transform(permission.datePermission, 'yyyy-MM-dd')
    this.selectedPermission = permission
    this.idIdentifier = permission.idIdentifier
    this.nameEmployee = permission.nameEmployee
    this.lastNameEmployee = permission.lastNameEmployee    
    this.typePermission = permission.typePermission
    this.datePerm = formattedDate!
    this.disableTextbox = true;
  } 

  CleanData() {
    this.isNewMaster = true;
    this.disableTextbox = true;
    this.idIdentifier = undefined;
    this.nameEmployee = "";
    this.lastNameEmployee = "";    
    this.typePermission = undefined;
    this.datePerm = "";
  }

  keyPressNumbers(event: any) {
    var charCode = (event.which) ? event.which : event.keyCode;
    // Only Numbers 0-9
    if ((charCode < 48 || charCode > 57)) {
      event.preventDefault();
      return false;
    } else {
      return true;
    }
  }
}
