using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trooper : Unit
{
    public LayerMask unitsLayer;
    public float maxCombatDistance = 10;

    private NavMeshAgent agent;

    private float time;
    private float timeOut = 1f;

    private Weapon weapon;

    private Unit currentTarget;
    // Start is called before the first frame update

    public override void Init()
    {
        this.agent = GetComponent<NavMeshAgent>();
        this.weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;

        //Reloj
        if(this.time > this.timeOut)
        {
            this.time = 0;
            if(this.currentTarget == null)
            {
                this.CheckSurrounding();
            }
            else
            {
                float distance = Vector3.Distance(
                    this.transform.position, this.currentTarget.transform.position
                );

                if (distance > this.maxCombatDistance)
                {
                    this.currentTarget = null;
                }
            }
        }

        if (this.weapon.isReady && this.currentTarget != null)
        {
            Vector3 target = this.currentTarget.transform.position;

            this.transform.LookAt(target);

            if(this.weapon.isReady)
            {
                this.weapon.Shoot();
            }
            this.weapon.Shoot();
        }
    }

    public void CheckSurrounding()
    {
        Collider[] nearUnits = Physics.OverlapSphere(
            this.transform.position,
            this.maxCombatDistance - 1,
            this.unitsLayer
        );

        for (int i = 0; i < nearUnits.Length; i++)
        {
            if(nearUnits[i].gameObject != this.gameObject)
            {
                Unit posibleEnemy = nearUnits[i].GetComponent<Unit>();

                if(posibleEnemy.faction != this.faction)
                {
                    this.currentTarget = posibleEnemy;
                }
            }
        }
    }

    // ==================================
    public override void ExecuteOrder(Vector3 worldPos)
    {
        this.agent.SetDestination(worldPos);
    }

}
