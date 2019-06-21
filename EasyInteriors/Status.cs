using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace EasyInteriors_Client
{
    public class Status : BaseScript
    {
        public static bool isPlayerCreatingInterior;

        public Status()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            isPlayerCreatingInterior = false;
        }
    }
}
