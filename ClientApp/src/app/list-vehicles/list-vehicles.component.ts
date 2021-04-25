import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/services/vehicle.service';
import { Vehicle } from '../models/vehicle';

@Component({
  selector: 'app-list-vehicles',
  templateUrl: './list-vehicles.component.html',
  styleUrls: ['./list-vehicles.component.css']
})
export class ListVehiclesComponent implements OnInit {

  vehicles;
  makes;
  filter: any = {};
  allVehicle: any;
  constructor(private vehicleService: VehicleService) { }

  ngOnInit(): void {
    this.vehicleService.getVehicles().subscribe(a => {
      this.vehicles = this.allVehicle = a;

    }
    )
    this.vehicleService.getMakes().subscribe(m => { this.makes = m })

  }

  onFilterChange() {
    var vehicles = this.allVehicle;
    if (this.filter.makeId)
      vehicles = vehicles.filter(v => v.make.id == this.filter.makeId)


    if (this.filter.modelId)
      vehicles = vehicles.filter(v => v.model.id == this.filter.modelId)

    this.vehicles = vehicles;
  }

  resetFilter() {
    this.filter = {};
    this.onFilterChange();
  }
}
