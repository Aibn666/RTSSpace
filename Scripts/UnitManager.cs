using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
   //Prototype
    public Camera sceneCamera;
    public SelectionBox selectionBox;

    private Plane groundPlane;

    //End Prototype

    public List<Unit> units;
    public List<Unit> selectedUnits;

    private bool selecting;

    // Start is called before the first frame update
    void Awake()
    {
        //this.agent = GetComponent<NavMeshAgent>();
        this.units = new List<Unit>();

        this.selectedUnits = new List<Unit>();

        this.groundPlane.SetNormalAndPosition(Vector3.up, Vector3.zero);

        this.selecting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.selecting = true;
            this.selectionBox.Begin(Input.mousePosition);
        }

        if(this.selecting)
        {
            if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                this.selectionBox.Drag(Input.mousePosition);

                //Seleccion de unidades
                foreach (Unit u in this.units)
                {
                    Vector2 screenCoord = this.sceneCamera.WorldToScreenPoint(u.transform.position);

                    if(this.selectionBox.selectionRect.Contains(screenCoord))
                    {
                        if(!u.IsSelected)
                        {
                            u.IsSelected = true;
                            this.selectedUnits.Add(u);
                        }
                    }
                    else
                    {
                        if(u.IsSelected)
                        {
                            u.IsSelected = false;
                            this.selectedUnits.Remove(u);
                        }
                    }
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            this.selectionBox.End();
            this.selecting = false;

            if (!this.selectionBox.IsValid())
            {
                for(int i = 0; i < this.selectedUnits.Count; i++)
                {
                    this.selectedUnits[i].IsSelected = false;
                }
                this.selectedUnits.Clear();

                Ray ray = this.sceneCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    GameObject go = hit.collider.gameObject;

                    Unit u = go.GetComponent<Unit>();
                    if (u != null)
                    {
                        u.IsSelected = true;
                        this.selectedUnits.Add(u);
                    }
                }
            }
        }



        if(Input.GetMouseButtonDown(1))
        {
            //calcular posicion de destino
            Ray ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
            float distance;

            groundPlane.Raycast(ray, out distance);
            Vector3 point = ray.GetPoint(distance);

            foreach(Unit u in this.selectedUnits)
            {
                u.ExecuteOrder(point);
            }
            //mover el agente
            //this.agent.SetDestination(point);
        }
    }
}
