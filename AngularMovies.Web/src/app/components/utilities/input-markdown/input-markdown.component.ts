import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-input-markdown',
  templateUrl: './input-markdown.component.html',
  styleUrls: ['./input-markdown.component.css']
})
export class InputMarkdownComponent {

  @Output()
  changeMarkdown = new EventEmitter<string>();

  @Input()
  markdownContent = '';

  onMarkdownChange(event: any){
    this.changeMarkdown.emit(event.target.value);
  }

}
