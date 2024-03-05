import { outputAst } from '@angular/compiler';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {  FormBuilder, FormGroup, Validators } from '@angular/forms';
import { movieTheaterCreationDto, movieTheaterDto } from '../movie-theaters.model';
import { coordinatesMap } from '../../utilities/map/coordinate';

@Component({
  selector: 'app-movie-theater-form',
  templateUrl: './movie-theater-form.component.html',
  styleUrls: ['./movie-theater-form.component.css']
})
export class MovieTheaterFormComponent implements OnInit {

  @Input()
  model!: movieTheaterDto;

  constructor(private formBuilder: FormBuilder ) { }

  @Output()
  onSaveChanges = new EventEmitter<movieTheaterCreationDto>();

  initialcoordinates: coordinatesMap[] = [];
  
  form!: FormGroup;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['', {
        validators: [Validators.required]
      }],
      longitude: ['', {
        validators: [Validators.required]
      }], 
      latitude: ['', {
        validators: [Validators.required]
      }]
    });

    if(this.model !== undefined){
      this.form.patchValue(this.model);
      this.initialcoordinates.push({latitude: this.model.latitude, longitude: this.model.longitude});
    }
  }

  saveChanges(){
    this.onSaveChanges.emit(this.form.value);
  }

  onSelectedLocation(coorditnates: coordinatesMap){
    this.form.patchValue(coorditnates);

  }
}
