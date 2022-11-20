using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class BuildManager : MonoBehaviour
{
    public LayerMask whereToPlace;
    public GameObject[] buildingsPrefabs;

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
                    switch (this.buildMode){
                        case "Fighter":
                        Instantiate(this.buildingsPrefabs[0]);
                        break;
                        case "Acorazado":
                        Instantiate(this.buildingsPrefabs[1]);
                        break;
                        case "Bomber":
                        Instantiate(this.buildingsPrefabs[2]);
                        break;
                        case "Destructor":
                        Instantiate(this.buildingsPrefabs[3]);
                        break;
                        case "NaveMadre":
                        Instantiate(this.buildingsPrefabs[4]);
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