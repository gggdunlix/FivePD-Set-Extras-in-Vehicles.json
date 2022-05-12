using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using FivePD.API;
using FivePD.API.Utils;
using CitizenFX.Core.Native;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace forceextras
{
    public class forceextras
    {
        public class Plugin : FivePD.API.Plugin
        {
            internal Plugin()
            {

                EventHandlers["FivePD::Client::SpawnVehicle"] += new Action<int, int>(EnableExtras); //Natixco

            }


            private void EnableExtras(int playerServerID, int vehicleNetworkID)
            {
                

                Vehicle pvehicle = Game.PlayerPed.CurrentVehicle;
                var vehiclename = Game.PlayerPed.CurrentVehicle.DisplayName;
                var config = API.LoadResourceFile("fivepd", "/config/vehicles.json");
                var json = JObject.Parse(config);
                JToken policeVehicles = json["police"];
                Debug.Write("Vehicle Name: " + vehiclename);

                JToken playerVehicleConfig = policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString() == vehiclename);

                JToken extras = playerVehicleConfig["extras"];
                
                if (extras != null)
                {



                    Debug.Write("\n Extras:" + extras);

                    // First disable any extras
                    pvehicle.ToggleExtra(1, false);
                    pvehicle.ToggleExtra(2, false);
                    pvehicle.ToggleExtra(3, false);
                    pvehicle.ToggleExtra(4, false);
                    pvehicle.ToggleExtra(5, false);
                    pvehicle.ToggleExtra(6, false);
                    pvehicle.ToggleExtra(7, false);
                    pvehicle.ToggleExtra(8, false);
                    pvehicle.ToggleExtra(9, false);
                    pvehicle.ToggleExtra(10, false);
                    pvehicle.ToggleExtra(11, false);
                    pvehicle.ToggleExtra(12, false);
                    foreach (int extra in extras)
                    {
                        pvehicle.ToggleExtra(extra, true);
                        Debug.Write("\nExtra " + extra + " activated.");
                    }
                }
                else
                {
                    Debug.Write("\n" + vehiclename + " has no extras defined in vehicles.json.");
                }









            }
        }
    }
}
