using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlteroGames.GreatWar.Units
{
    public class UnitHandler : MonoBehaviour
    {
        public static UnitHandler instance;

        [SerializeField]
        private BasicUnit worker, warrior, healer;
        private void Start()
        {
            instance = this;
        }

        public (int cost, int attack, int attack_range, int health, int armor) GetBasicUnit(string type)
        {
            BasicUnit unit;
            switch (type)
            {
                case "worker":
                    unit = worker;
                    break;
                case "warrior":
                    unit = warrior;
                    break;
                case "healer":
                    unit = healer;
                    break;
                default:
                    Debug.LogError($" Unit type: {type} could not be found or does not exist");
                    return (0, 0, 0, 0, 0);

            }
            return (unit.Cost, unit.Attack, unit.AttackRange, unit.Health, unit.Armor);
        }
        public void SetBasicUnitStats(Transform type)
        {
            foreach (Transform child in type)
            {
                foreach (Transform unit in child)
                {
                    string unitName = child.name.Substring(0, child.name.Length - 1).ToLower();
                    var stats = GetBasicUnit(unitName);
                    Player.PlayerUnit pU;

                    if( type == AlteroGames.GreatWar.Player.PlayerManager._instance.playerUnits )
                    {
                        pU = unit.GetComponent<Player.PlayerUnit>();
                        pU.cost = stats.cost;
                        pU.attack = stats.attack;
                        pU.attack_range = stats.attack_range;
                        pU.health = stats.health;
                        pU.armor = stats.armor;
                    }
                    else if( type == AlteroGames.GreatWar.Player.PlayerManager._instance.enemyUnits)
                    {
                        // set enemy stats
                    }

                    // Добавить други свойства юнита
                }
            }
        }
    }
}