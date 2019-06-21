using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace EasyInteriors_Client
{
    public class InteriorCreation : BaseScript
    {
        public InteriorCreation()
        {

        }

        public static async Task DrawMarkerUnderPlayer()
        {
            World.DrawMarker(MarkerType.VerticalCylinder, Game.PlayerPed.Position + new Vector3(0f, 0f, -1f), Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), System.Drawing.Color.FromArgb(255, 255, 255));
        }
    }
}
