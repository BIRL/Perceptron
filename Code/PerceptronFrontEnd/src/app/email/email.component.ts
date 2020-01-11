import { router } from './../app.routes';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import {MatToolbarModule, MatSidenavModule, MatCardModule, MatButtonModule, MatIconModule, MatMenuModule, MatInputModule} from '@angular/material';
import {AppComponent} from '../app.component';
import { AngularFireAuth } from 'angularfire2/auth';
import * as firebase from 'firebase/app';

import { Router } from '@angular/router';
import { moveIn, fallIn } from '../router.animations';

@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css']
  // animations: [moveIn(), fallIn()],
  // host: { '[@moveIn]': '' }
})

export class EmailComponent implements OnInit {
  disabled: boolean;
  disabled1: boolean;
  password: any;
  email = new FormControl('', [Validators.required, Validators.email]);
  getErrorMessage() {
    return this.email.hasError('required') ? 'You must enter a value' :
        this.email.hasError('email') ? 'Not a valid email' :
            '';
  }
  hide = true;

  state: string = '';
  error: any;
  user_name: any;
  constructor(public myapp: AppComponent, public af: AngularFireAuth, private router: Router) {
    var x = this.router;
    this.af.authState.subscribe
      (user => {
        // x.navigateByUrl('/yoohoo');
      })
  }


  onSubmit(formData) {
    if (formData.valid) {
      var x = this.router;
      console.log(formData.value);
      var email = formData.value.email
      var password = formData.value.password;
      var cred = firebase.auth.EmailAuthProvider.credential(email, password);
      this.af.auth.signInWithEmailAndPassword(email, password).then((success) => {
        this.myapp.disabled1=false;
        localStorage.setItem('login','1');
        x.navigate(['/search']);
      }).catch((err) => {
        var errorCode = err.code;
        var errorMessage = err.message;
        if (errorCode === 'auth/wrong-password') {
          alert('Wrong password.');
        } else {
          alert(errorMessage);
        }
        console.log(err);
        this.error = err;
      });
    }
  }

  ngOnInit() {
    this.myapp.disabled=true;
  }
  ngOnDestroy(){
    if (this.myapp.disabled1){
      this.myapp.disabled=false;
    }
    else{
      if (this.af.auth.currentUser.displayName){
        localStorage.setItem('logged_in_user', this.af.auth.currentUser.displayName);
      }else{
        localStorage.setItem('logged_in_user', 'user');
      }
      this.myapp.logged_in_user = localStorage.getItem('logged_in_user');
      this.myapp.disabled=true;
    }
    }
}