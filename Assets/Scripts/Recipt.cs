using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Utility;

public class Recipt : MonoBehaviour
{
    private int frontMostZ = 0;
    private Material blurEffect;
    private Material defaultEffect;
    private void Awake()
    {
        blurEffect = Resources.Load<Material>("BlurImage");
        defaultEffect = this.GetComponent<SpriteRenderer>().material;
        this.GetComponent<SpriteRenderer>().material = blurEffect;
        Debug.Log("test");
        Debug.Log(blurEffect);
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

     private void OnMouseOver()
        {
            this.GetComponent<SpriteRenderer>().material = defaultEffect;
        }
     
    void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().material = blurEffect;
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
