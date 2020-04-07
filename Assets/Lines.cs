using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    LineRenderer lr;
    LineRenderer lr2;
    LineRenderer lr3;

    public Transform point1;
    public Transform point2;

    void Start()
    {
        lr = this.GetComponent<LineRenderer>();
        lr.SetPosition(0, point1.position);
        lr.SetPosition(1, point2.position);
        lr.enabled = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lr.SetPosition(0, point1.position);
        lr.SetPosition(1, point2.position);
    }
}
