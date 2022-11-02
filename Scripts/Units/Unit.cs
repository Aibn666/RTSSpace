using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public GameObject selectionMarker;

    protected bool selected;

    //pruebas
    public UnitManager manager;

    public bool IsSelected
    {
        get 
        {
            return this.selected;
        }
        set 
        {
            this.selectionMarker.SetActive(value);
            this.selected = value;
        }
    }
    // ==============================================
    void Start()
    {
        this.IsSelected = false;

        this.manager = GameObject.FindObjectOfType<UnitManager>();
        this.manager.units.Add(this);
        this.Init();
    }

    // ==============================================
    void OnDestroy()
    {

    }
    // ==============================================
    public virtual void Init()
    {
        
    }

    // ==============================================
    public virtual void ExecuteOrder(Vector3 worldPos)
    {

    }

}