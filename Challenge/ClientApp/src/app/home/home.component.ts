import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})


export class HomeComponent implements OnInit {

  constructor(private http: HttpClient) { }

  minRange: number = 0;
  maxRange: number = 9999;
  insertedAccessCode: number;
  availableAttempts: string;
  validRange: boolean;
  response: string;
  enableInput: boolean = true;

  ngOnInit() {
    this.GetAvailableAttempts();  
  }

  public ValidateAccessCode() {
    this.http.get('https://localhost:5001/validate/' + this.insertedAccessCode, { responseType: 'text' })
      .subscribe(r => {
        this.response = r;
        this.GetAvailableAttempts();
      },
       error => { console.log(error) }
      );
  }

  public GetAvailableAttempts() {
    this.http.get('https://localhost:5001/available-attempts', { responseType: 'text' })
      .subscribe(attempts => {
        this.availableAttempts = attempts;
        if (this.availableAttempts == '0') {
          this.enableInput = false;
        }
      },
        error => { console.log(error) }
      );
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

    if (this.insertedAccessCode < 0 || this.insertedAccessCode > 9999) {
      this.validRange = false;
    }

    return this.validRange;
  }

}
