using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildManager : MonoBehaviour
{
    public GameObject[] buildingsPrefabs;
    public LayerMask whereToPlace;

    public Camera mainCamera;

    private string buildMode;

    // Start is called before the first frame update
    void Start()
    {
        this.buildMode = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.buildMode != string.Empty)
        {
            if(Input.GetMouseButtonDown(0))
            {
                switch (this.buildMode)
                {
                    case "NaveMadre":
                    Instantiate(this.buildingsPrefabs[0]);
                    break;
                }
                this.buildMode = string.Empty;
            }
        }
    }
    public void StartBuildMode(string mode)
    {
        this.buildMode = mode;
    }

}