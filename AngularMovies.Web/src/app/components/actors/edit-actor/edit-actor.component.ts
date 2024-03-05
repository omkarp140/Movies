import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { actorCreationDto, actorDto } from '../acotrs.model';

@Component({
  selector: 'app-edit-actor',
  templateUrl: './edit-actor.component.html',
  styleUrls: ['./edit-actor.component.css']
})
export class EditActorComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute) { }

  model: actorDto = { 
                        name: 'Tom Holland', 
                        dateOfBirth: new Date(),
                        biography: 'default value',
                        picture: 'https://upload.wikimedia.org/wikipedia/commons/thumb/5/5a/Cillian_Murphy_at_Berlinale_2024%2C_Ausschnitt.jpg/220px-Cillian_Murphy_at_Berlinale_2024%2C_Ausschnitt.jpg' 
                    }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      // alert(params['id']);
    });
  }

  saveChanges(actorCreationDto: actorCreationDto) {
    console.log(actorCreationDto);
  }
}
