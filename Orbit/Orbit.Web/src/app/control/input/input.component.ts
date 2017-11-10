import { Component, Input, Output,EventEmitter } from '@angular/core';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css']
})
export class InputComponent   {
  @Input() field : string;
  @Input() model : string;
  @Input() readOnly : boolean;
  @Output() modelChange = new EventEmitter();


  change(newValue){
    this.model = newValue;
    this.modelChange.emit(newValue);
  }
}
