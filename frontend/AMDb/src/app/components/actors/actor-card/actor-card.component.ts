import { ActorConcise } from './../../../core/models/actor-concise';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-actor-card',
  templateUrl: './actor-card.component.html',
  styleUrls: ['./actor-card.component.css']
})
export class ActorCardComponent implements OnInit {
  @Input() actor: ActorConcise;

  constructor() { }

  ngOnInit() {
  }
}
