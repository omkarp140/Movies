import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { movieCreationDto, movieDto } from '../movies.model';
import { mutlipleSelectorModel } from '../../utilities/mutliple-selector/multiple-selector.model';

@Component({
  selector: 'app-form-movie',
  templateUrl: './form-movie.component.html',
  styleUrls: ['./form-movie.component.css']
})
export class FormMovieComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) {}

  @Input()
  model!: movieDto

  @Output()
  onSaveChanges = new EventEmitter<movieCreationDto>();

  nonSelectedGenres: mutlipleSelectorModel[] = [
    { key: 1, value: 'Drama' },
    { key: 2, value: 'Action'},
    { key: 3, value: 'Comedy'},
    { key: 4, value: 'Thriller'},
    { key: 5, value: 'Sci-Fi'}
  ];

  nonSelectedTheaters: mutlipleSelectorModel[] = [
    { key: 1, value: 'Pune'},
    { key: 2, value: 'Mumbai'},
    { key: 3, value: 'Satara'}
  ];

  selectedGenres: mutlipleSelectorModel[] = [];
  selectedTheaters: mutlipleSelectorModel[] = [];

  form!: FormGroup;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      title: ['', {
        validators: [Validators.required]
      }],
      summary: '',
      inTheaters: false,
      trailer: '',
      releaseDate: '',
      poster: '',
      genreIds: '',
      movieTheaterIds: ''
    });

    if(this.model !== undefined){
      this.form.patchValue(this.model);
    }
  }

  saveChanges(){
    const genreIds = this.selectedGenres.map(value => value.key);
    this.form.get('genreIds')?.setValue(genreIds);

    const theaterIds = this.selectedTheaters.map(value => value.key);
    this.form.get('movieTheaterIds')?.setValue(theaterIds);

    this.onSaveChanges.emit(this.form.value);
  }

  onImageSelected(file: File) {
    this.form.get('poster')?.setValue(file);    
  }

  changeMarkdown(content: string){
    this.form.get('summary')?.setValue(content);

  }

}
