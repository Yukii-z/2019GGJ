using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
	public Button nextButton;
    public ReceiptManager receiptManager;

    // Start is called before the first frame update
    void Start()
    {
    	nextButton = this.gameObject.GetComponent<Button>();
    	nextButton.onClick.AddListener(onNextClick);

        receiptManager = GameObject.FindGameObjectWithTag("ReceiptManager").GetComponent<ReceiptManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onNextClick() {
        receiptManager.SwitchToNextScene();
    }
}
