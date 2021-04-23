import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { VehicleService } from 'src/services/vehicle.service';
import "rxjs/add/observable/forkJoin";
import { Observable } from 'rxjs-compat';
import { SaveVehicle } from '../models/SaveVehicle';
import { KeyValuePair } from '../models/KeyValuePair';
import * as _ from 'underscore';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent implements OnInit {
  makes: any;
  //KeyValuePair[];
  models: any[];

  // KeyValuePair[];
  features: any;
  vehicle: SaveVehicle = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    features: [],
    lastUpdate: '',
    contact: {
      name: '',
      email: '',
      phone: '',
    },

  };
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService, private notifier: NotifierService) {


    route.params.subscribe(p => {
      this.vehicle.id = +p['id'];
    })

  }

  ngOnInit() {
    var sources = [
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures(),
    ]
    Observable.forkJoin(sources).subscribe(data => {
      this.makes = data[0];
      this.features = data[1];
      if (this.vehicle.id) {
        this.setVehicle(data[2]);
        this.populateModels();
      }
    },
      error => {
        if (error.status == 400) {
          this.router.navigate["/home"];
        }
      }
    );
    if (this.vehicle.id)
      sources.push(this.vehicleService.getVehicle(this.vehicle.id));



  }

  private setVehicle(v) {
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.makeId = v.model.id;
    this.vehicle.isRegistered = v.isRegistered;
    this.vehicle.contact = v.contact;
    this.vehicle.features = _.pluck(v.featurs, 'id');
  }
  onMakeChange() {
    this.populateModels();
    delete this.vehicle.modelId;
  }

  private populateModels() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : "";
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

    if (this.vehicle.id) {
      this.vehicleService.update(this.vehicle).subscribe(x => {
        this.notifier.notify("Error", "This is error");
      });
    } else {

      this.vehicleService.create(this.vehicle).subscribe(
        x => console.log(x),
        error => {
          // this.notifier.notify('error', 'You are awesome! I mean it!');
        }

      )
    }
  }


}
