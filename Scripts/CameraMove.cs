using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform cameraAnchor;

    private int border;
    private Vector2 screenBorder;
    private Vector2 middleScreen;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        this.border = 10;
        this.screenBorder = new Vector2(Screen.width - this.border, Screen.height - this.border);
        this.middleScreen = new Vector2(Screen.width/2, Screen.height/2);
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0)) {
            Vector2 mouse = Input.mousePosition;
            if(
                (Input.mousePosition.x < this.border) ||
                (Input.mousePosition.x > (this.screenBorder.x)) ||
                (Input.mousePosition.y < this.border) ||
                (Input.mousePosition.y > (this.screenBorder.y))
            ){
                this.movement = mouse - this.middleScreen;
                this.movement.z = this.movement.y;
                this.movement.y = 0;
                this.movement = this.movement.normalized * 5;

                this.cameraAnchor.Translate(this.movement);
            }
        }
    }
}
