using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Resources : MonoBehaviour
{
    [SerializeField]
	private float amountEnergy=0.005f; 
    
    public ResourcesUi resourcesUi;
    
    public float availableEnergy= 100.0f;
   
    public enum EnergyStationType{
		ENERGY
	}

    [SerializeField]
	private EnergyStationType energyStationType;

    //Check the Trigger here
    private void OnTriggerStay( Collider other)
    {
        Energy energy=other.transform.gameObject.GetComponent<Energy>();
        if(energy != null)
        {
            shipIsUnderStation(energy);
        }
    }
	

    //

    private void shipIsUnderStation(Energy energy){

		if (energyStationType == EnergyStationType.ENERGY) {
            this.availableEnergy -= amountEnergy;
            this.resourcesUi.refreshEnergy (this.availableEnergy);
			energy.ModifyEnergy (amountEnergy);
		}
	}
    
}
