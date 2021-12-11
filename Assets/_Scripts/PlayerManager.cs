using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlteroGames.GreatWar.InputManager;

namespace AlteroGames.GreatWar.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager _instance;

        public Transform playerUnits;

        public Transform enemyUnits;

        void Start()
        {
            _instance = this;
            Units.UnitHandler.instance.SetBasicUnitStats(playerUnits);
            Units.UnitHandler.instance.SetBasicUnitStats(enemyUnits);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Debug.Log("Pressed primary button.");

            if (Input.GetMouseButtonDown(1))
                Debug.Log("Pressed secondary button.");

            if (Input.GetMouseButtonDown(2))
                Debug.Log("Pressed middle click.");

            InputHandler._instance.HandleUnitMovement();
        }
    }
}