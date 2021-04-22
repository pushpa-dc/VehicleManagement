import { Component } from '@angular/core';
import { VehicleService } from 'src/services/vehicle.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  makes;
  constructor(private makeService: VehicleService) {

  }

  collapse() {
    this.isExpanded = false;
  }

  ngOnInit(): void {


  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
