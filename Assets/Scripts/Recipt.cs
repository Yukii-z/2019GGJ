using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Recipt : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<Collider2D>();
    }

    public void MouseAbove()
        {
            //TODO
            //what happens when mouse is above
        }

    private void Update()
    {
        throw new System.NotImplementedException();
    }

    public void DragItem()
    {
        //TODO
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
