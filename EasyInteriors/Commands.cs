﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using EasyInteriors_Client;
using static CitizenFX.Core.Native.API;

namespace EasyInteriors
{
    public class Commands : BaseScript
    {
        public Commands()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            RegisterCommand("createinterior", new Action<int, List<object>, string>((source, args, raw) =>
            {
                Status.isPlayerCreatingInterior = true;

                TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "[EasyInteriors]", "Walk to where you want your entrance to be, and type '/interior:set' or type '/interior:cancel' to cancel this operation" }
                });

                Tick += InteriorCreation.DrawMarkerUnderPlayer;

            }), false);

            RegisterCommand("interior:cancel", new Action<int, List<object>, string>((source, args, raw) =>
            {
                if (Status.isPlayerCreatingInterior)
                {
                    Status.isPlayerCreatingInterior = false;

                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "[EasyInteriors]", "Interior creation cancelled!" }
                    });

                    Tick -= InteriorCreation.DrawMarkerUnderPlayer;
                }
                else
                {
                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "[EasyInteriors]", "You aren't creating an interior" }
                    });
                }
            }), false);
        }
    }
}