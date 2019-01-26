using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager2D : MonoBehaviour
{
    GameObject RayCast(bool singleItem=true)
    {
        if (singleItem)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                return hit.collider.gameObject;
            }
            else
            {
                return null;
            }  
        }
        else
        {
            return null;
        }
    }

}
