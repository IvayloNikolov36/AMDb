import { ActorsService } from './../../../core/services/actors/actors.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

const urlPattern = '^((http)|(https)):\/\/.+';

@Component({
  selector: 'app-add-actor',
  templateUrl: './add-actor.component.html',
  styleUrls: ['./add-actor.component.css']
})
export class AddActorComponent implements OnInit {
  addActorForm: FormGroup;

  constructor(
    private actors: ActorsService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.addActorForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      birthName: ['', [Validators.required, Validators.min(4), Validators.maxLength(50)]],
      birthDate: ['', []],
      birthPlace: ['', [Validators.minLength(4), Validators.maxLength(50)]],
      height: ['', [Validators.min(0.5), Validators.max(2.4)]],
      imageUrl: ['', [Validators.pattern(urlPattern)]],
      biography: ['', [Validators.required, Validators.minLength(20), Validators.maxLength(1000)]]
    });
  }

  addActor() {
    this.actors.add(this.addActorForm.value).subscribe(data => {
      this.router.navigate(['/home']);
    });
  }

  get f() {
    return this.addActorForm.controls;
  }
}
