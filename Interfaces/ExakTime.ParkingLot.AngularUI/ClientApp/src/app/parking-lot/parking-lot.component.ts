import { Component } from '@angular/core';
import { ParkingLot } from './ParkingLot';
import { Vehicle } from '../vehicle/Vehicle';
import { ParkingLotService } from './ParkingLotService';

@Component({
  selector: 'parking-lot',
  templateUrl: './parking-lot.component.html',
})
export class ParkingLotComponent {

  constructor(private parkingLotService: ParkingLotService) {

    this.loadParkedVehicleList();

  }

  public unPark(vehicle: Vehicle): void {

    this.parkingLotService.unParkVehicle(vehicle.id)
      .subscribe(result => {

        this.loadParkedVehicleList();

      }, error => console.log(error));

  }

  public loadParkedVehicleList(sortField?: string): void {

    this.parkingLotService.getParkingLot().subscribe(
      result => {

        if (sortField) {

          let sortedVehicles = result.vehicles.sort(
            (a, b) => {

              if (sortField == "id") {

                return this.sortComparerById(a, b);

              } else if (sortField == "vehicleType") {

                return this.sortComparerByVehicleType(a, b);

              }

            });

          this.parkingLot.vehicles = sortedVehicles;
        }
        else {
          this.parkingLot = result
        }

      },
      error => console.log(error));

  }

  public onParked(parked: boolean) {

    if (parked) {

      this.loadParkedVehicleList();

    }

  }

  public sortVehiclesById() {

    this.loadParkedVehicleList("id");

  }

  public sortVehiclesByType() {

    this.loadParkedVehicleList("vehicleType");

  }

  public sortComparerById(a: Vehicle, b: Vehicle) {

    if (!a) {

      return -1;

    } else if (!b) {

      return 1;

    } else if (a.id < b.id) {

      return -1;

    } else if (b.id < a.id) {

      return 1;

    } else {

      return 0;

    }

  }

  public sortComparerByVehicleType(a: Vehicle, b: Vehicle) {

    if (!a) {

      return -1;

    } else if (!b) {

      return 1;

    } else if (a.vehicleType < b.vehicleType) {

      return -1;

    } else if (b.vehicleType < a.vehicleType) {

      return 1;

    } else {

      return 0;

    }

  }

  public parkingLot: ParkingLot;


}
