﻿using System;
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

                EventHandlers["FivePD::Client::SpawnVehicle"] += new Action<int, int>(EnableExtras); //Natixco
                EventHandlers["FivePD::Client::SpawnVehicle"] += new Action<int, int>(setLivery); //Natixco

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
        }
    }
}
