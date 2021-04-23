import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SaveVehicle } from 'src/app/models/SaveVehicle';


@Injectable({
  providedIn: 'root'
})
export class VehicleService {


  constructor(private http: HttpClient) { }

  getMakes() {
    return this.http.get("/api/makes");
  }

  getFeatures() {
    return this.http.get("/api/features");
  }

  create(vehicle) {
    return this.http.post('/api/vehicles', vehicle);
  }

  getVehicle(id) {
    return this.http.get("/api/vehicles/" + id);
  }

  update(vehicle: SaveVehicle) {
    return this.http.put("/api/vehicles/" + vehicle.id, vehicle);
  }

}
