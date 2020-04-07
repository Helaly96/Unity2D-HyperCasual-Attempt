using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public Vector2 target;

    private void OnDestroy()
    {
        if( Vector2.Distance(this.transform.position,target) > 0.4f)
        {
            Debug.Log("GOAL!");
        }
    }
}
