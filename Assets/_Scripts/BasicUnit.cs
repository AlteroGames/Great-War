using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlteroGames.GreatWar.Units
{
    [CreateAssetMenu(fileName = "New Unit", menuName = "New Unit/Basic")]
    public class BasicUnit : ScriptableObject
    {
        public enum unitType
        {
            Worker,
            Warrior,
            Healer
        };
        [Space(15)]
        [Header("Unit setting")]
        public unitType Type;
        public string Name;

        public GameObject humanPrefab;
        public GameObject infectedPrefab;

        [Space(15)]
        [Header("Unit Base stats")]
        [Space(40)]
        public int Cost;
        public int Attack;
        public int AttackRange;
        public int Health;
        public int Armor;
    }
}