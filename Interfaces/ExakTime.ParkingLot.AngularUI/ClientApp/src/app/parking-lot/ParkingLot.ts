import { IDictionary } from "../../infrastructure/IDictionary";
import { Vehicle } from "../vehicle/Vehicle";

export interface ParkingLot {
  totalMoneyCollected: number;
  totalMoneyCollectedByVehicleType: IDictionary<number>;
  vehicles: Vehicle[];
}
