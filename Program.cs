using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ParkingLot_SquadStack
{
    class Program
    {
        //This is Client Application Start point.
        public static void Main(string[] args)
        {
            IList<string> result = ReadFromFile();
            WriteToFile(result);
        }

        //This method writes the given list of string to a file.
        public static void WriteToFile(IList<string> output)
        {
            using StreamWriter file = new("output.txt");
            for (int i = 0; i < output.Count; i++)
            {
                if (i == output.Count - 1)
                    file.Write(output[i]);
                else
                    file.WriteLine(output[i]);
            }
        }

        //This method reads the input as string from the given file.
        public static IList<string> ReadFromFile()
        {
            IList<string> result = new List<string>();
            ParkingLot parkingLot = null;
            try
            {
                StreamReader reader = new StreamReader("input.txt");
                using (reader)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] inputs = line.Split(" ");
                        //different commands and their respective actions are taken in this if.. else if.. else block
                        if (inputs[0].Equals("Create_parking_lot"))
                        {
                            parkingLot = new ParkingLot(Convert.ToInt32(inputs[1]));
                            result.Add("Created parking of " + inputs[1] + " slots");
                        }
                        else if (inputs[0].Equals("Park"))
                        {
                            int currentSlot = parkingLot.GetAParkingSlot();
                            if (currentSlot == -1)
                            {
                                result.Add("Parking is Full");
                            }
                            else
                            {
                                parkingLot.CarEntry(new Car(inputs[1], Convert.ToInt32(inputs[3])));
                                result.Add("Car with vehicle registration number \"" + inputs[1] + "\" has been parked at slot number " + currentSlot);
                            }
                        }
                        else if (inputs[0].Equals("Slot_numbers_for_driver_of_age"))
                        {
                            result.Add(parkingLot.SlotNumbersWithCertainAge(Convert.ToInt32(inputs[1])));
                        }
                        else if (inputs[0].Equals("Slot_number_for_car_with_number"))
                        {
                            result.Add(parkingLot.SlotNumberWithACertainVehicleNumber(inputs[1]));
                        }
                        else if (inputs[0].Equals("Leave"))
                        {
                            Car currentCar = parkingLot.GetCurrentCar(Convert.ToInt32(inputs[1]));
                            parkingLot.CarExit(Convert.ToInt32(inputs[1]));
                            result.Add("Slot number " + inputs[1] + " vacated, the car with vehicle registration number \"" + currentCar.GetVehicleNumber() + "\" left the space, the driver of the car was of age " + currentCar.GetAgeOfDriver());
                        }
                        else if (inputs[0].Equals("Vehicle_registration_number_for_driver_of_age"))
                        {
                            result.Add(parkingLot.VehicleNumbersWithCertainAge(Convert.ToInt32(inputs[1])));
                        }
                        else
                        {
                            result.Add("Invalid input");
                        }

                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("That file does not exist!");
            }
            catch (IOException)
            {
                Console.WriteLine("Oops! Something Wrong happened!");
            }

            return result;
        }
    }
}
