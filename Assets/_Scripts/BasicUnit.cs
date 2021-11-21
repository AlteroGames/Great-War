using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlteroGames.GreatWar.Units
{
    [CreateAssetMenu(fileName = "New Unit", menuName = "New Unit/Basic") ]
    public class BasicUnit : ScriptableObject
    {
        public enum unitType
        {
            WORKER,
            WARRIOR,
            HEALER
        };

        // Привести в красивый вид
        public bool mIsPlayerUnit;

        public unitType mType;
        public string mName;

        public GameObject humanPrefab;
        public GameObject infectedPrefab;

        public int mCost;
        public int mAttack;
        public int mHealth;
        public int mArmor;
    }
}