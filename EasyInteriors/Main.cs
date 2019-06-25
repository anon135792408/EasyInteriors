using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace EasyInteriors_Client
{
    class Main : BaseScript
    {
        List<dynamic> loadedInteriors;

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
        }
    }
}
