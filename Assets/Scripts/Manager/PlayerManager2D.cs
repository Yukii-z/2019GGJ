using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager2D : MonoBehaviour
{
    GameObject[] RayCast(bool singleItem=true)
    {
        if (singleItem)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin ,ray.direction , Color.red);
            RaycastHit2D hit;
            if (Physics2D.Raycast(ray, out hit, int.MaxValue))
            {
                return hit;
            }
        }
    }

}
