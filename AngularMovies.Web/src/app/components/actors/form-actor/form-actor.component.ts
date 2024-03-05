import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { actorCreationDto, actorDto } from '../acotrs.model';

@Component({
  selector: 'app-form-actor',
  templateUrl: './form-actor.component.html',
  styleUrls: ['./form-actor.component.css']
})
export class FormActorComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) {}

  @Input()
  model!: actorDto;

  form!: FormGroup;

  @Output()
  onSaveChanges = new EventEmitter<actorCreationDto>();

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['', {
        validators: [Validators.required]
      }],
      dateOfBirth: '',
      picture: ''
    });

    if(this.model !== undefined){
      this.form.patchValue(this.model);
    }
  }

  saveChanges(){
    this.onSaveChanges.emit(this.form.value);
  }

  onImgSelected(image: any){
    this.form.get('picture')?.setValue(image);

  }

  changeMarkdown(content: string) {
    this.form.get('biography')?.setValue(content)
  }

}
