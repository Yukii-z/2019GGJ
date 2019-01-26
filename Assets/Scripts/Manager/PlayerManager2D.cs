using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager2D : MonoBehaviour
{
    GameObject[] RayCast(bool singleItem=true)
    {
        if (singleItem)
        {
            Ray ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.DrawRay(ray.origin ,ray.direction , Color.red);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, int.MaxValue))
            {
                return hit;
            }
        }
    }

}
