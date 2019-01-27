using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePreviousScene : MonoBehaviour
{
	public Button previousButton;
	public ReceiptManager receiptManager;

    // Start is called before the first frame update
    void Start()
    {
    	previousButton = this.gameObject.GetComponent<Button>();
    	previousButton.onClick.AddListener(onPreviousClick);

        receiptManager = GameObject.FindGameObjectWithTag("ReceiptManager").GetComponent<ReceiptManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onPreviousClick() {
        receiptManager.SwitchToPreviousScene();
    }
}
