using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Utility;
using UnityEngine.UI;

public class Receipt : MonoBehaviour
{
    public GameObject receiptManager;
    private int frontMostZ = 0;
    private Material blurEffect;
    private Material defaultEffect;
    public float zoomScale = 0.3f;
    private void Awake()
    {
        gameObject.AddComponent<BoxCollider2D>();
        blurEffect = Resources.Load<Material>("BlurImage");
        defaultEffect = this.GetComponent<SpriteRenderer>().material;
        this.GetComponent<SpriteRenderer>().material = blurEffect;
        receiptManager = GameObject.FindGameObjectWithTag("ReceiptManager");
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

    void OnMouseOver()
        {
            receiptManager.GetComponent<ReceiptManager>().BringReceiptToForeground(this.gameObject);
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
