import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  form: FormGroup = this.fb.group({
    email: [null, [Validators.required]],
    password: [null, [Validators.required]]
  });

  constructor(
    private fb: FormBuilder,
    private router: Router
  ) { }

  login(): void {
    this.router.navigate(['/vehiculos'])
  }

}
