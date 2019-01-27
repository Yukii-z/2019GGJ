using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class ReceiptManager : MonoBehaviour
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
        Vector3 v3 = receiptInParticular.transform.position;
        v3.z = -1; // foreground
        receiptInParticular.transform.position = v3;
    }

    // make all z-index 0
    void ZeroOutReceiptLayers() {
        foreach (GameObject go in Receipts) {
            Vector3 v3 = go.transform.position;
            v3.z = 0; // neutral
            go.transform.position = v3;
        }
    }
}
