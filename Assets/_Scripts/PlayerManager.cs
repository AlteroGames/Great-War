using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlteroGames.GreatWar.InputManager;

namespace AlteroGames.GreatWar.PlayerManager
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager _instance;

        void Start()
        {
            _instance = this;
        }

        void Update()
        {
            InputHandler._instance.HandleUnitMovement();
        }
    }
}