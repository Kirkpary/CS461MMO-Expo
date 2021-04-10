﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Com.Oregonstate.MMOExpo
{
    public class PortalTeleporterScript : MonoBehaviour
    {
        public Launcher launcher;
        public GameObject PortalPrefab;
        private string DefaultWorld = "PortalLobby";

        void OnTriggerEnter (Collider other) 
        {
            if (PortalPrefab.name != "")
            {
                launcher.Connect(PortalPrefab.name);
            }
            else
            {
                Debug.Log("No RoomName specified. Defaulting to " + DefaultWorld + ".", this);
                launcher.Connect(DefaultWorld);
            }
        }
    }
}   
