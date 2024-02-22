import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent implements OnInit {
  
  @Input()
  maxRating = 5;

  @Input()
  selectedRating = 0;
  previousRating = 0;
  ratingArr: any;

  @Output()
  onRating: EventEmitter<number> = new EventEmitter<number>();
  
  ngOnInit(): void {
    this.ratingArr = Array(this.maxRating).fill(0);
  }

  handleMouseEnter(index: number){
    this.selectedRating = index + 1;
  }

  handleMouseLeave(){
    if(this.previousRating !== 0 ){
      this.selectedRating = this.previousRating;
    }else{
      this.selectedRating = 0;
    }
  }

  rate(index: number){
    this.selectedRating = index + 1;
    this.previousRating = this.selectedRating;
    this.onRating.emit(this.selectedRating);
  }

}
