using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AlteroGames.GreatWar.Player
{
   [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerUnit : MonoBehaviour
    {
        private NavMeshAgent navAgent;

        public int cost, attack, attack_range, health, armor;
        private void OnEnable()
        {
            navAgent = GetComponent<NavMeshAgent>();
        }
        public void MoveUnit( Vector3 _destination)
        {
            navAgent.SetDestination(_destination);
        }
    }
}