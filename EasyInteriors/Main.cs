using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using EasyInteriors;
using static CitizenFX.Core.Native.API;

namespace EasyInteriors_Client
{
    class Main : BaseScript
    {
        public static List<dynamic> loadedInteriors;

        public Main()
        {
            EventHandlers["easyinteriors:DownloadInteriors"] += new Action<List<dynamic>>(DownloadInteriors);
        }

        public void DownloadInteriors(List<dynamic> interiors)
        {
            Debug.WriteLine("[EasyInteriors] Downloaded " + interiors.Count + " interiors");
            if (interiors.Count > 0)
            {
                Debug.WriteLine("[EasyInteriors] The first interior is " + interiors[0].name);
                loadedInteriors = new List<dynamic>(interiors);
            }
            Tick -= DrawMarkers;

            if (interiors.Count > 0)
                Tick += DrawMarkers;
        }

        private async Task DrawMarkers()
        {
            foreach (dynamic i in Main.loadedInteriors)
            {
                World.DrawMarker(MarkerType.VerticalCylinder, i.entrance + new Vector3(0f, 0f, -1f), Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), System.Drawing.Color.FromArgb(255, 255, 255));
                World.DrawMarker(MarkerType.VerticalCylinder, i.exit + new Vector3(0f, 0f, -1f), Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), System.Drawing.Color.FromArgb(255, 255, 255));
            }
        }
    }
}
