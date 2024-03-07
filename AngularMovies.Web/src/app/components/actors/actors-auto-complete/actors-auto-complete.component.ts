import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatTable } from '@angular/material/table';

@Component({
  selector: 'app-actors-auto-complete',
  templateUrl: './actors-auto-complete.component.html',
  styleUrls: ['./actors-auto-complete.component.css']
})
export class ActorsAutoCompleteComponent implements OnInit {

  constructor() {}

  control: FormControl = new FormControl();

  actors = [
    { name: 'Tom Holland', picture: 'https://upload.wikimedia.org/wikipedia/commons/thumb/3/3c/Tom_Holland_by_Gage_Skidmore.jpg/220px-Tom_Holland_by_Gage_Skidmore.jpg'},
    { name: 'Tom Hanks', picture: 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Tom_Hanks_TIFF_2019.jpg/220px-Tom_Hanks_TIFF_2019.jpg'},
    { name: 'Samuel L Jackson', picture: 'https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/SamuelLJackson.jpg/220px-SamuelLJackson.jpg'},
    { name: 'Cillian Murphy', picture: 'https://upload.wikimedia.org/wikipedia/commons/thumb/5/5a/Cillian_Murphy_at_Berlinale_2024%2C_Ausschnitt.jpg/220px-Cillian_Murphy_at_Berlinale_2024%2C_Ausschnitt.jpg'}
  ];

  selectedActors: { name: string, picture: string }[] = [];
  originalActors = this.actors;
  columnsToDisplay = ['picture', 'name', 'character', 'actions']

  @ViewChild(MatTable) table: MatTable<any> | undefined;

  ngOnInit(): void {
    this.control.valueChanges.subscribe(value => {
      this.actors = this.originalActors;
      this.actors = this.actors.filter(actor => actor.name.indexOf(value) !== -1)
    });    
  }

  optionSelected(event: MatAutocompleteSelectedEvent){
    console.log(event);
    this.selectedActors.push(event.option.value);
    this.control.patchValue('');
    if(this.table !== undefined){
      this.table.renderRows();
    }
  }

  remove(actor: any){
    const index = this.selectedActors.findIndex(a => a.name === actor.name)
    this.selectedActors.splice(index, 1);
    this.table?.renderRows();
  }

  dropped(event: CdkDragDrop<any[]>){
    const previousIndex = this.selectedActors.findIndex(a => a === event.item.data);
    moveItemInArray(this.selectedActors, previousIndex, event.currentIndex);
    this.table?.renderRows();
  }
}
