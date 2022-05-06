using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using FivePD.API;
using FivePD.API.Utils;
using CitizenFX.Core.Native;
using Newtonsoft.Json.Linq;

namespace forceextras
{
    public class forceextras
    {
        public class Plugin : FivePD.API.Plugin
        {
            internal Plugin()
            {

                Tick += EnableExtras;
            }

            private async Task EnableExtras()
            {



                    Vehicle PlayerCar = Game.PlayerPed.VehicleTryingToEnter;
                    if (PlayerCar.IsDamaged)
                    { }
                    else
                    {
                        var VehicleName = PlayerCar.DisplayName;
                        int num = JToken.op_Explicit(JObject.Parse(CitizenFX.Core.Native.API.LoadResourceFile(CitizenFX.Core.Native.API.GetCurrentResourceName(), "config/forcereg.json"))["ForceDept"]);
                        await Delay(500);
                    }


            }
        }
    }
}
}