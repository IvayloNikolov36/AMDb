import { ActorsService } from './../../core/services/actors/actors.service';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from 'src/app/material.module';
import { AddActorComponent } from './add-actor/add-actor.component';

const routes: Routes = [
  { path: 'add', component: AddActorComponent }
];

@NgModule({
  declarations: [
  AddActorComponent,
],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialModule,
    FlexLayoutModule,
    RouterModule.forChild(routes),
  ],
  providers: [
    ActorsService
  ]
})
export class ActorsModule { }
