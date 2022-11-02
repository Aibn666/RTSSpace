using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trooper : Unit
{
    private NavMeshAgent agent;
    // Start is called before the first frame update

    public override void Init()
    {
        this.agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ==================================
    public override void ExecuteOrder(Vector3 worldPos)
    {
        this.agent.SetDestination(worldPos);
    }

}
