using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Utility;

public class Recipt : MonoBehaviour
{
    private int frontMostZ = 0;
    private void Awake()
    {
        Debug.Log("test");
    }

    public void MouseAbove()
        {
            //TODO
            //what happens when mouse is above
        }

    private void Update()
    {
        // throw new System.NotImplementedException();
    }

    // public void DragItem()
    // {
    //     //TODO
    // }

    void OnMouseDrag() {
        Vector2 curScreenPoint = Camera.main.ScreenToWorldPoint(
            new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Debug.Log("Dragging to mouse point: X:" + curScreenPoint.x + " Y: " + curScreenPoint.y);
        Library.SetPosition2D(this.gameObject, curScreenPoint);
    }

    void OnMouseDown() {
        // Debug.Log("OnMouseDown test!!");
    }

    void OnMouseOver() {
        // Debug.Log("OnMouseOver test!!");
    }
    
    public void ZoomIn()
    {
        //TODO
    }

    public void FlipItemThatZoomedIn()
    {
        //TODO
    }
}
