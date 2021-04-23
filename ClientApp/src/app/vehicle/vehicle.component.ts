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
  features: any = {
    features: [],
    contact: {}
  };
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
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : "";
    delete this.vehicle.modelId;
  }

  onFeatureToggle(featureId, $event) {
    if ($event.target.checked)
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    this.vehicleService.create(this.vehicle).subscribe(
      x => console.log(x)

    )
  }
}
