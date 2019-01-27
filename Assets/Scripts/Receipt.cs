﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Utility;
using UnityEngine.UI;

public class Receipt : MonoBehaviour
{
    private ReceiptManager receiptManager;
    private int frontMostZ = 0;
    private Material blurEffect;
    private Material defaultEffect;
    private float zoomScale = 2.0f;
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
                ZoomIn();
            }
        }
     
    void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().material = blurEffect;
        // Debug.Log("OnMouseOver test!!");
    }

   

    public void ZoomIn()
    {
        //set all receipts unseeable for raycast
        foreach (GameObject go in ReceiptManager.Instance.Receipts)
        {
            go.layer = 2;
        }
        //the screen goes dark
        GameObject darkScreenPic = GameObject.Find("DarkBackground");
        SpriteEffect effect = darkScreenPic.AddComponent<SpriteEffect>();
        effect.numberAssignment(5f, SpriteEffect.EffectType.ShowSomeImage);
        //creat a copy in UI layer
        Sprite receiptSprite = GetComponent<SpriteRenderer>().sprite;
        GameObject zoomInObj = Instantiate(Resources.Load<GameObject>("Prefab/ZoomInImage"),darkScreenPic.transform.parent);
        zoomInObj.GetComponent<Image>().sprite = receiptSprite;
        zoomInObj.GetComponent<Image>().SetNativeSize();
        zoomInObj.transform.localScale = zoomScale * zoomInObj.transform.localScale;
        StartCoroutine(waitAndAddCanvasImage(0.5f, zoomInObj));
    }
    
    IEnumerator waitAndAddCanvasImage(float waitTime, GameObject zoomInObj)
    {
        yield return new WaitForSeconds(waitTime);
        zoomInObj.AddComponent<CanvasImage>();
    }

    public void FlipItemThatZoomedIn()
    {
        //TODO
    }
}