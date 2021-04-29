import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//import { environment } from 'environments/environment';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})


export class HomeComponent implements OnInit {

  constructor(private http: HttpClient) { }

  insertedAccessCode: number;
  validRange: boolean;

  ngOnInit() {
  }

  public ValidateAccessCode() {
    const url = 'https://localhost:5001/validate/' + this.insertedAccessCode;
    return this.http.get(url);
  }

  public GetAvailableAttempts() {
    const url = 'https://localhost:5001/validate/available-attemps' ;
    return this.http.get(url);
  }

  onSubmit(f: NgForm) {
    if (this.CheckConstrains()) {

      this.ValidateAccessCode();
    }
  }


  CheckConstrains() {
    this.validRange = true;

    if (this.insertedAccessCode == null) {
      this.validRange =  false;
    }

    if (this.insertedAccessCode < 0) {
      this.validRange = false;
    }

    return this.validRange;
  }

}
