using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlteroGames.GreatWar.Player;
namespace AlteroGames.GreatWar.InputManager
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler _instance;

        private RaycastHit hit;

        private List<Transform> selectedUnits = new List<Transform>();

        private bool isDragging = false;

        private Vector3 mousePos;

        void Start()
        {
            _instance = this;
        }

        private void OnGUI()
        {
            if (isDragging)
            {
                Rect rect = MultuSelect.GetScreenRect(mousePos, Input.mousePosition);
                MultuSelect.DrawScreenRect(rect, new Color(0f, 0f, 0f, 0.25f));
                MultuSelect.DrawScreenRectBorder(rect, 3, Color.blue);
            }
        }
        public void HandleUnitMovement()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    LayerMask layerhit = hit.transform.gameObject.layer;

                    switch (layerhit.value)
                    {
                        case 8: // Units layer
                            {
                                //Debug.Log("Unit mouse click");
                                // do something                           
                                SelectUnit(hit.transform);
                                break;
                            }
                        default:
                            {
                                isDragging = true;
                                DeselectUnits();
                                // do something
                                break;
                            }

                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                foreach (Transform child in Player.PlayerManager._instance.playerUnits)
                {
                    foreach (Transform unit in child)
                    {
                        if (isWithInSelectionBounds(unit))
                        {
                            SelectUnit(unit, true);
                        }
                    }
                }
                isDragging = false;
            }

            if (Input.GetMouseButtonDown(1) && HaveSelectedUnits())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    LayerMask layerhit = hit.transform.gameObject.layer;

                    switch (layerhit.value)
                    {
                        case 8: // Units layer
                            {
                                //Debug.Log("Unit mouse click");
                                // do something                           

                                break;
                            }
                        case 9: // Enemy layer
                            {

                                //attack set target
                                break;
                            }
                        default:
                            {
                                foreach (Transform unit in selectedUnits)
                                {
                                    PlayerUnit pU = unit.gameObject.GetComponent<PlayerUnit>();
                                    pU.MoveUnit(hit.point);
                                }
                                // do something
                                break;
                            }

                    }
                }
            }
        }
        private void SelectUnit(Transform unit, bool is_multi_select = false)
        {
            Debug.Log("SelectUnit");

            if (!is_multi_select)
                DeselectUnits();

            selectedUnits.Add(unit);
            // Подсветка объекта
            GameObject highlight = unit.Find("Highlight").gameObject;
            if (!highlight.activeSelf)
                highlight.SetActive(true);
        }
        private void DeselectUnits()
        {
            for (int i = 0; i < selectedUnits.Count; i++)
            {
                GameObject highlight = selectedUnits[i].Find("Highlight").gameObject;
                highlight.SetActive(false);
            }
            selectedUnits.Clear();
        }

        private bool isWithInSelectionBounds(Transform tf)
        {
            if (!isDragging)
                return false;
            Camera cam = Camera.main;
            Bounds vpBounds = MultuSelect.GetVPBound(cam, mousePos, Input.mousePosition);
            return vpBounds.Contains(cam.WorldToViewportPoint(tf.position));
        }
        private bool HaveSelectedUnits()
        {
            if (selectedUnits.Count > 0)
                return true;
            else
                return false;
        }
    }
}
