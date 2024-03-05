import { Component, OnInit } from '@angular/core';
import { actorCreationDto } from '../acotrs.model';

@Component({
  selector: 'app-create-actors',
  templateUrl: './create-actors.component.html',
  styleUrls: ['./create-actors.component.css']
})
export class CreateActorsComponent implements OnInit{

  ngOnInit(): void {
    
  }

  saveChanges(actorCreationDto: actorCreationDto){
    console.log(actorCreationDto);
  }

}
