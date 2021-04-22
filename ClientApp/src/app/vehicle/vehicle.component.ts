import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/services/vehicle.service';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent implements OnInit {

  makes;
  models;
  features;
  vehicle: any = {};
  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(m => {
      this.makes = m;
      console.log(this.makes)
    });
    this.vehicleService.getFeatures().subscribe(featues => {
      this.features = featues;
    })
  }

  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models : "";
  }

}
