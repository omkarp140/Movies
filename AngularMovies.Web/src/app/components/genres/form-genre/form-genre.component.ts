import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { firstLetterUppercase } from '../../../Validators/firstLetterUppercase';
import { genreCreationDto } from '../genres.models';

@Component({
  selector: 'app-form-genre',
  templateUrl: './form-genre.component.html',
  styleUrls: ['./form-genre.component.css']
})
export class FormGenreComponent implements OnInit {
  router: any;

  constructor(private formBuilder: FormBuilder){}

  @Input()
  model!: genreCreationDto;

  form!: FormGroup;

  @Output()
  onSaveChanges: EventEmitter<genreCreationDto> = new EventEmitter<genreCreationDto>();

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['', {
        validators: [Validators.required, firstLetterUppercase()]
      }]
    });

    if(this.model !== undefined){
      this.form.patchValue(this.model);
    }
  }

  saveChanges(){
    this.onSaveChanges.emit(this.form.value);
  }

  getErrorMessageFieldName(){
    const field = this.form.get('name');

    if(field?.hasError('required')){
      return 'This is required field';
    }

    if(field?.hasError('firstLetterUppercase')){
      return field.getError('firstLetterUppercase').message;
    }
    return '';
  }


}
