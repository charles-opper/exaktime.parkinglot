import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ParkingLot } from "./ParkingLot";
import { Observable } from "rxjs";
import { Vehicle } from "../vehicle/Vehicle";

@Injectable({
  providedIn: 'root'
})
export class ParkingLotService {

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.parkingLotApiUri = baseUrl + 'api/parkinglot';

  }

  public getParkingLot(): Observable<ParkingLot> {

    return this.http.get<ParkingLot>(this.parkingLotApiUri);

  }

  public parkVehicle(vehicleType: string): Observable<Vehicle> {

    return this.http.post<Vehicle>(this.parkingLotApiUri, { vehicleType: vehicleType });

  }

  public unParkVehicle(vehicleId: number): Observable<Vehicle> {

    return this.http.delete<Vehicle>(this.parkingLotApiUri + "/" + vehicleId)

  }

  public parkingLotApiUri: string;

}
