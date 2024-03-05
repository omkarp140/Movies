import { Component, EventEmitter, Input, Output } from '@angular/core';
import { toBase64 } from '../utilities';

@Component({
  selector: 'app-input-img',
  templateUrl: './input-img.component.html',
  styleUrls: ['./input-img.component.css']
})
export class InputImgComponent {

  @Input()
  urlCurrentImage!: any;

  imageBase64!: string;

  @Output()
  onImgSelected = new EventEmitter<File>();

  change(event : any){
    if(event.target.files.length > 0){
      const file: File = event.target.files[0];
      toBase64(file).then((value: any) => this.imageBase64 = value as string);
      this.onImgSelected.emit(file);
      this.urlCurrentImage = null;
    }

  }

}
