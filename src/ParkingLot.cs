using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot_SquadStack
{
    public class ParkingLot
    {
        SortedDictionary<int, Car> slotToCarMap;
        int capacity;
        public ParkingLot(int size)
        {
            capacity = size;
            slotToCarMap = new SortedDictionary<int, Car>();

            for (int i = 1; i <= capacity; i++)
            {
                slotToCarMap.Add(i, null);
            }
        }

        public bool CarEntry(Car car)
        {
            foreach (var kvp in slotToCarMap)
            {
                if (kvp.Value == null)
                {
                    slotToCarMap[kvp.Key] = car;
                    return true;
                }
            }

            return false;
        }

        public int GetAParkingSlot()
        {
            foreach (var kvp in slotToCarMap)
            {
                if (kvp.Value == null)
                {
                    return kvp.Key;
                }
            }

            return -1;
        }

        public void CarExit(int slot)
        {
            slotToCarMap[slot] = null;
        }

        public string VehicleNumbersWithCertainAge(int age)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var kvp in slotToCarMap)
            {
                if (kvp.Value != null && kvp.Value.GetAgeOfDriver() == age)
                {
                    sb.Append(kvp.Value.GetVehicleNumber() + ",");
                }
            }

            return sb.ToString().TrimEnd(',');
        }

        public string SlotNumberWithACertainVehicleNumber(string vehicleNumber)
        {
            foreach (var kvp in slotToCarMap)
            {
                if (kvp.Value != null && kvp.Value.GetVehicleNumber().Equals(vehicleNumber))
                {
                    return kvp.Key.ToString();
                }
            }

            return string.Empty;
        }

        public string SlotNumbersWithCertainAge(int age)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var kvp in slotToCarMap)
            {
                if (kvp.Value != null && kvp.Value.GetAgeOfDriver() == age)
                {
                    sb.Append(kvp.Key + ",");
                }
            }

            return sb.ToString().TrimEnd(',');
        }

        public Car GetCurrentCar(int slot)
        {
            return slotToCarMap[slot];
        }
    }
}