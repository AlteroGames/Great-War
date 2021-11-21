using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlteroGames.GreatWar.InputManager
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler _instance;

        private RaycastHit hit;


        void Start()
        {
            _instance = this;
        }

        void Update()
        {

        }

        public void HandleUnitMovement()
        {
            if( Input.GetMouseButtonDown(0) )
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                if( Physics.Raycast( ray, out hit ) )
                {
                    LayerMask layerhit = hit.transform.gameObject.layer;

                    switch ( layerhit.value )
                    {
                        case 8: // Units layer
                            {
                                // do something
                                SelectUnit(hit.transform);
                                break;
                            }
                        default:
                            {
                                // do something
                                break;
                            }

                    }
                }
            }
        }
        private void SelectUnit( Transform unit )
        {
            unit.Find( "Highlight" ).gameObject.SetActive( true );
        }
    }
}
