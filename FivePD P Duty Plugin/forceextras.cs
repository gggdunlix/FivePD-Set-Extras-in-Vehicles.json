/*
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using FivePD.API;
using FivePD.API.Utils;
using CitizenFX.Core.Native;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json.Schema;

namespace forceextras
{
    public class forceextras
    {
        public class Plugin : FivePD.API.Plugin
        {
            internal Plugin()
            {
                //Version 2.0: Sets extras and livery!  Now removed annoying debug crap!
                //Version 3.0.0 Merges the Callsign Plate plugin into this plugin. Now, adding "SetCallsignOnPlate" to true in the vehicle's config should set the vehicle's plate to be your callsign.
                EventHandlers["FivePD::Client::SpawnVehicle"] += new Action<int, int>(EnableExtras); //Natixco
                EventHandlers["FivePD::Client::SpawnVehicle"] += new Action<int, int>(setLivery); //Natixco
                EventHandlers["FivePD::Client::SpawnVehicle"] += new Action<int, int>(setPlate); //Natixco

            }


            private void EnableExtras(int playerServerID, int vehicleNetworkID)
            {
                

                Vehicle pvehicle = Game.PlayerPed.CurrentVehicle;
                var vehiclename = Game.PlayerPed.CurrentVehicle.DisplayName.ToLower();
                var config = API.LoadResourceFile(API.GetCurrentResourceName(), "/config/vehicles.json");
                var json = JObject.Parse(config);
                JToken policeVehicles = json["police"];

                if (policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename)["extras"] != null)
                {
                JToken playerVehicleConfig = policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename);
                    JToken extras = playerVehicleConfig["extras"];

                    if (extras.ToString() == "all")
                    {
                        pvehicle.ToggleExtra(1, true);
                        pvehicle.ToggleExtra(2, true);
                        pvehicle.ToggleExtra(3, true);
                        pvehicle.ToggleExtra(4, true);
                        pvehicle.ToggleExtra(5, true);
                        pvehicle.ToggleExtra(6, true);
                        pvehicle.ToggleExtra(7, true);
                        pvehicle.ToggleExtra(8, true);
                        pvehicle.ToggleExtra(9, true);
                        pvehicle.ToggleExtra(10, true);
                        pvehicle.ToggleExtra(11, true);
                        pvehicle.ToggleExtra(12, true);
                    }
                    else
                    if (extras.ToString() == "none")
                    {
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
                    }
                    else
                    {
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
                            if (pvehicle.ExtraExists(extra))
                            {
                                pvehicle.ToggleExtra(extra, true);
                            } else
                            {
                                Debug.Write("\nExtra " + extra + " doesn't exist on vehicle " + vehiclename.ToLower());
                            }
                        }
                    }
                } else
                {

                }
                return;
            }

            private void setLivery(int playerServerID, int vehicleNetworkID)
            {


                Vehicle pvehicle = Game.PlayerPed.CurrentVehicle;
                var vehiclename = Game.PlayerPed.CurrentVehicle.DisplayName.ToLower();
                var config = API.LoadResourceFile(API.GetCurrentResourceName(), "/config/vehicles.json");
                var json = JObject.Parse(config);
                JToken policeVehicles = json["police"];

                if (policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename)["livery"] != null)
                {
                    JToken playerVehicleConfig = policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename);
                    JToken livery = playerVehicleConfig["livery"];
                    API.SetVehicleLivery(pvehicle.Handle, ((int)livery));

                }
                else
                {

                }
                return;
            }
            private void setPlate(int playerServerID, int vehicleNetworkID)
            {


                Vehicle pvehicle = Game.PlayerPed.CurrentVehicle;
                var vehiclename = Game.PlayerPed.CurrentVehicle.DisplayName.ToLower();
                var config = API.LoadResourceFile(API.GetCurrentResourceName(), "/config/vehicles.json");
                var json = JObject.Parse(config);
                JToken policeVehicles = json["police"];

                if (policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename)["SetCallsignOnPlate"] != null)
                {
                    JToken playerVehicleConfig = policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename);
                    if (((bool)playerVehicleConfig["SetCallsignOnPlate"]))
                    {
                        if (pvehicle.NetworkId > 0)
                        {
                            PlayerData data = Utilities.GetPlayerData();
                            string Callsign = data.Callsign;
                            //with help from Grandpa Rex
                            var vehicle = Entity.FromNetworkId(pvehicle.NetworkId);
                            API.SetVehicleNumberPlateText(vehicle.Handle, Callsign);

                        }
                        else
                        {
                            Debug.WriteLine("FivePD | Vehicles.json extended functions plugin: There was an error setting your callsign to your vehicle's plate.");
                        }
                    }
                    else if (!((bool)playerVehicleConfig["SetCallsignOnPlate"])) { } else
                    {
                        Debug.WriteLine("FivePD | Vehicles.json extended functions plugin: Your \"SetCallsignOnPlate\" field in vehicles.json should be 'true' or 'false'");
                    }

                }
                return;
            }
        }
    }
}
*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using FivePD.API;
using FivePD.API.Utils;
using CitizenFX.Core.Native;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json.Schema;

namespace forceextras
{
    public class forceextras
    {
        public class Plugin : FivePD.API.Plugin
        {
            internal Plugin()
            {
                //Version 2.0: Sets extras and livery!  Now removed annoying debug crap!
                //Version 3.0.0 Merges the Callsign Plate plugin into this plugin. Now, adding "SetCallsignOnPlate" to true in the vehicle's config should set the vehicle's plate to be your callsign.
                //Version 3.5.0 merges all methods into one, needs to be TESTED & FIXED
                EventHandlers["FivePD::Client::SpawnVehicle"] += new Action<int, int>(setVehicleSettings); //Natixco

            }
            private void setVehicleSettings(int playerServerID, int vehicleNetworkID)
            {
                Vehicle pvehicle = Game.PlayerPed.CurrentVehicle;
                var vehiclename = Game.PlayerPed.CurrentVehicle.DisplayName.ToLower();
                var config = API.LoadResourceFile(API.GetCurrentResourceName(), "/config/vehicles.json");
                var json = JObject.Parse(config);
                JToken policeVehicles = json["police"];
                //extras:
                if (policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename)["extras"] != null)
                {
                JToken playerVehicleConfig = policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename);
                    JToken extras = playerVehicleConfig["extras"];

                    if (extras.ToString() == "all")
                    {
                        pvehicle.ToggleExtra(1, true);
                        pvehicle.ToggleExtra(2, true);
                        pvehicle.ToggleExtra(3, true);
                        pvehicle.ToggleExtra(4, true);
                        pvehicle.ToggleExtra(5, true);
                        pvehicle.ToggleExtra(6, true);
                        pvehicle.ToggleExtra(7, true);
                        pvehicle.ToggleExtra(8, true);
                        pvehicle.ToggleExtra(9, true);
                        pvehicle.ToggleExtra(10, true);
                        pvehicle.ToggleExtra(11, true);
                        pvehicle.ToggleExtra(12, true);
                    }
                    else
                    if (extras.ToString() == "none")
                    {
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
                    }
                    else
                    {
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
                            if (pvehicle.ExtraExists(extra))
                            {
                                pvehicle.ToggleExtra(extra, true);
                            } else
                            {
                                Debug.Write("\nExtra " + extra + " doesn't exist on vehicle " + vehiclename.ToLower());
                            }
                        }
                    }
                } else
                {

                }
                return;
                if (policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename)["livery"] != null)
                {
                    
                    // should prob find a way to check if the livery exists. Some users are getting issues that (maybe) will crash inside this part. Gonna have to debug, first need to find the actual cause of the error!
                    JToken playerVehicleConfig = policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename);
                    JToken livery = playerVehicleConfig["livery"];
                    API.SetVehicleLivery(pvehicle.Handle, ((int)livery));

                }
                else
                {

                }
                return;
                if (policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename)["SetCallsignOnPlate"] != null)
                {
                    JToken playerVehicleConfig = policeVehicles.FirstOrDefault(vehicle => vehicle["vehicle"].ToString().ToLower() == vehiclename);
                    if (((bool)playerVehicleConfig["SetCallsignOnPlate"]))
                    {
                        if (pvehicle.NetworkId > 0)
                        {
                            PlayerData data = Utilities.GetPlayerData();
                            string Callsign = data.Callsign;
                            //with help from Grandpa Rex
                            var vehicle = Entity.FromNetworkId(pvehicle.NetworkId);
                            API.SetVehicleNumberPlateText(vehicle.Handle, Callsign);

                        }
                        else
                        {
                            Debug.WriteLine("FivePD | Vehicles.json extended functions plugin: There was an error setting your callsign to your vehicle's plate.");
                        }
                    }
                    else if (!((bool)playerVehicleConfig["SetCallsignOnPlate"])) { } else
                    {
                        Debug.WriteLine("FivePD | Vehicles.json extended functions plugin: Your \"SetCallsignOnPlate\" field in vehicles.json should be 'true' or 'false'");
                    }

                }
            }


            
        }
    }
}
