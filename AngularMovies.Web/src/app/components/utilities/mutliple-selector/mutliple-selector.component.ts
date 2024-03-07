import { Component, Input, OnInit } from '@angular/core';
import { mutlipleSelectorModel } from './multiple-selector.model';

@Component({
  selector: 'app-mutliple-selector',
  templateUrl: './mutliple-selector.component.html',
  styleUrls: ['./mutliple-selector.component.css']
})
export class MutlipleSelectorComponent implements OnInit {
  constructor() {}

  @Input()
  SelectedItems: mutlipleSelectorModel[] = [];

  @Input()
  NonSelectedItems: mutlipleSelectorModel[] = [];

  ngOnInit(): void {
    
  }

  select(item: mutlipleSelectorModel, index: number){
    this.SelectedItems.push(item);
    this.NonSelectedItems.splice(index, 1);
  }

  deselect(item: mutlipleSelectorModel, index: number){
    this.NonSelectedItems.push(item);
    this.SelectedItems.splice(index, 1);
  }

  selectAll(){
    this.SelectedItems.push(...this.NonSelectedItems);
    this.NonSelectedItems = [];
  }

  deselectAll(){
    this.NonSelectedItems.push(...this.SelectedItems);
    this.SelectedItems = [];
  }

}
