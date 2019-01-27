using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasImage : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ZoomOut();
            Debug.Log("zoomout");
        }
    }

    void ZoomOut()
    {
        //set all receipts unseeable for raycast
        foreach (GameObject go in ReceiptManager.Instance.Receipts)
        {
            go.layer = 8;
        }
        //the screen goes bright
        GameObject darkScreenPic = GameObject.Find("DarkBackground");
        SpriteEffect effect = darkScreenPic.AddComponent<SpriteEffect>();
        effect.numberAssignment(3f, SpriteEffect.EffectType.FadeImage);
        //Destroy the game object
        Destroy(gameObject);
    }
}
