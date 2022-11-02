using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField]
	    private float currentEnergy;

	[SerializeField]
	    private float maxEnergy;

    public void ModifyEnergy(float e){
        currentEnergy += e;
		if (currentEnergy > maxEnergy) {
			currentEnergy = maxEnergy;
		}
	}
}
