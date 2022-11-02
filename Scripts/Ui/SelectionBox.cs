using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    public Rect selectionRect;

    private RectTransform reactTransform;

    private Vector3 mouseStart;

    private float minSize;
    // ==================================
    // Start is called before the first frame update
    void Start()
    {
        this.selectionRect.Set(0,0,0,0);

        this.reactTransform = GetComponent<RectTransform>();
        this.reactTransform.gameObject.SetActive(false);   

        this.minSize = (Screen.width * 0.05f + Screen.height * 0.05f) / 2; 
    }
    // ==================================
    public bool IsValid()
    {
        return this.selectionRect.size.magnitude > this.minSize;
    }
    // ==================================
    public void Begin(Vector3 mousePos)
    {
        this.mouseStart = mousePos;

        this.selectionRect.Set(mousePos.x, mousePos.y, 0, 0);

        this.reactTransform.gameObject.SetActive(true);

        this.reactTransform.offsetMin = this.selectionRect.min;
        this.reactTransform.offsetMax = this.selectionRect.max;
    }

    // ==================================
    public void Drag(Vector3 mousePos)
    {
        if(mousePos.x < this.mouseStart.x)
        {
            this.selectionRect.xMin = mousePos.x;
            this.selectionRect.xMax = this.mouseStart.x;
        }
        else
        {
            this.selectionRect.xMin = this.mouseStart.x;
            this.selectionRect.xMax = mousePos.x;
        }

        if(mousePos.y < this.mouseStart.y)
        {
            this.selectionRect.yMin = mousePos.y;
            this.selectionRect.yMax = this.mouseStart.y;
        }
        else
        {
            this.selectionRect.yMin = this.mouseStart.y;
            this.selectionRect.yMax = mousePos.y;
        }

        this.reactTransform.offsetMin = this.selectionRect.min;
        this.reactTransform.offsetMax = this.selectionRect.max;
    }
    // ==================================
    public void End()
    {
        this.reactTransform.gameObject.SetActive(false);
    }

}
