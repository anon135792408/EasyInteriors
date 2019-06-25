using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace EasyInteriors_Client
{
    public class Interior
    {
        public Interior(Vector3 entrance, Vector3 exit, string name)
        {
            this.entrance = entrance;
            this.exit = exit;
            this.name = name;
        }

        public string name { get; set; }
        public Vector3 entrance { get; set; }
        public Vector3 exit { get; set; }
    }
}
