using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesUi : MonoBehaviour
{
    public GameObject popUpPanel;
    public TextMeshProUGUI resourceQuantityText;
    public Resources resource;

    void OnMouseEnter()
    {
        popUpPanel.SetActive(true);
        Debug.Log(resourceQuantityText);
    }

    void OnMouseExit()
    {
        popUpPanel.SetActive(false);
    }

    // void mostrarEnergia()
    // {
    //     resourceQuantityText.text = resource.availableEnergy.ToString();
    // }

    // 	[SerializeField]
	// private GameObject interactionMessage;

	// [SerializeField]
	// private Text healthIndicator;

	// void FixedUpdate () {
	// 	interactionMessage.SetActive (false);
	// }

	// public void canInteract(){
	// 	interactionMessage.SetActive (true);
	// }

	public void refreshEnergy(float h){

		resourceQuantityText.text = ((int)h).ToString();

	}
}
