using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Utility;

public class Recipt : MonoBehaviour
{
    private ReceiptManager receiptManager;
    private int frontMostZ = 0;
    private Material blurEffect;
    private Material defaultEffect;
    private void Awake()
    {
        blurEffect = Resources.Load<Material>("BlurImage");
        defaultEffect = this.GetComponent<SpriteRenderer>().material;
        receiptManager = GameObject.FindGameObjectWithTag("ReceiptManager").GetComponent<ReceiptManager>();
        Debug.Log("receipt manager" + receiptManager.ToString());
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
            // receiptManager.BringReceiptToForeground(this.gameObject);
            this.GetComponent<SpriteRenderer>().material = defaultEffect;
            if (Input.GetMouseButtonDown(1))
            {
                //ZoomIn();
            }
        }
     
    void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().material = blurEffect;
        // Debug.Log("OnMouseOver test!!");
    }

   

    /*public void ZoomIn()
    {
        //set all recipts unseeable for raycast
        GameObject 
        if()
    }*/

    public void FlipItemThatZoomedIn()
    {
        //TODO
    }
}
