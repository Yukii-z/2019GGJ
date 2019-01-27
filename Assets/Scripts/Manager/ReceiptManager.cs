using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class ReceiptManager : MonoSingleton<ReceiptManager>
{
    public GameObject[] Receipts;
    public int maxScenes = 1;
    public GameObject previousButton;
    public GameObject nextButton;
    
    private int currentSceneNum;

    // Start is called before the first frame update
    void Start() {
        Receipts = GameObject.FindGameObjectsWithTag("Receipt");
        UpdateSceneReceipts();
        previousButton.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void BringReceiptToForeground(GameObject receiptInParticular) {
        ZeroOutReceiptLayers();
        Vector3 v3 = receiptInParticular.transform.position;
        v3.z = -1; // foreground
        Library.SetPosition3DWithoutSetRotation(receiptInParticular, v3);
    }

    // make all z-index 0
    void ZeroOutReceiptLayers() {
        foreach (GameObject go in Receipts) {
            Vector3 v3 = go.transform.position;
            v3.z = 0; // neutral
            Debug.Log("Zero Out v3 x:" + v3.x + " y:" + v3.y + " z:" + v3.z);
            Library.SetPosition3DWithoutSetRotation(go, v3);
        }
    }

    public void SwitchToNextScene() {
        if (currentSceneNum < maxScenes) {
            currentSceneNum++;
            nextButton.SetActive(true);
            previousButton.SetActive(true);
        }

        if (currentSceneNum == maxScenes) {
            nextButton.SetActive(false);
        }

        UpdateSceneReceipts();
    }

    public void SwitchToPreviousScene() {
        if (currentSceneNum > 0) {
            currentSceneNum--;
            nextButton.SetActive(true);
            previousButton.SetActive(true);
        } 

        if (currentSceneNum == 0) {
            previousButton.SetActive(false);
        }

        UpdateSceneReceipts();   
    }

    public void UpdateSceneReceipts() {
        foreach (GameObject go in Receipts) {
            Vector3 v3 = go.transform.position;

            // if not current scene, hide
            if (go.GetComponent<Receipt>().SceneNum != currentSceneNum) {
                go.SetActive(false); // neutral
            } else {
                // if currentScene show
                go.SetActive(true);
                v3.z = 0;
            }
            Library.SetPosition3D(go, v3);
        }
    }
}
