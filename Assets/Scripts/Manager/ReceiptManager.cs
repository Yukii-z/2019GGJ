using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class ReceiptManager : MonoSingleton<ReceiptManager>
{
    public GameObject[] Receipts;

    // Start is called before the first frame update
    void Start() {
        Receipts = GameObject.FindGameObjectsWithTag("Receipt");
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void BringReceiptToForeground(GameObject receiptInParticular) {
        ZeroOutReceiptLayers();
        Vector3 v3 = receiptInParticular.transform.localPosition;
        v3.z = -1; // foreground
        Library.SetPosition3D(receiptInParticular, v3);
    }

    // make all z-index 0
    void ZeroOutReceiptLayers() {
        foreach (GameObject go in Receipts) {
            Vector3 v3 = go.transform.localPosition;
            v3.z = 0; // neutral
            Debug.Log("Zero Out v3 x:" + v3.x + " y:" + v3.y + " z:" + v3.z);
            Library.SetPosition3D(go, v3);
        }
    }
}
