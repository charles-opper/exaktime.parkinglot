import { Component, Output, EventEmitter } from '@angular/core';
import { ParkingLotService } from '../parking-lot/ParkingLotService';

@Component({
  selector: 'vehicle',
  templateUrl: './vehicle.component.html',
})
export class VehicleComponent {

  constructor(private parkingLotService: ParkingLotService) { }

  @Output() parked = new EventEmitter<boolean>();

  public park(): void {

    this.parkingLotService.parkVehicle(this.vehicleType)
      .subscribe(result => {

        this.parked.emit(true);

      }, error => alert(error.message));

  }

  public vehicleType: string;
  public parkingLotApiUri: string;

}
