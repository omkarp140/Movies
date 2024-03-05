import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LeafletMouseEvent, Marker, latLng, marker, tileLayer } from 'leaflet';
import { coordinatesMap } from './coordinate';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {  

  constructor() {}

  @Input()
  initialCoordinates: coordinatesMap[] = [];

  @Output()
  onSelectedLocation = new EventEmitter<coordinatesMap>();

  ngOnInit(): void {
    this.layers = this.initialCoordinates.map(value => marker([value.latitude, value.longitude]));
  }

  options = {
    layers: [
      tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 18, attribution: 'Movies' })
    ],
    zoom: 15,
    center: latLng(18.546802447426177, -286.22648477554327)
  };

  layers: Marker<any>[] = [];

  handleMapClick(event: LeafletMouseEvent){
    const latitude = event.latlng.lat;
    const longitude = event.latlng.lng;
    console.log(latitude, longitude);
    this.layers = [];
    this.layers.push(marker([latitude, longitude]));
    this.onSelectedLocation.emit({latitude, longitude});
  }

}
