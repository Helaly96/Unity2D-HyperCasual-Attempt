using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    Rect Left;
    Rect Right;
    Rect Up;


    public GameObject WoodLeft;
    public GameObject WoodRight;
    public GameObject WoodMiddle;

    private Vector3 Left_First_touch;
    private Vector3 Right_First_touch;
    private Vector3 Top_First_Touch;


    private Vector3 Current_left;
    private Vector3 Current_Right;
    private Vector3 Current_Top;

    public  Transform UpperLimit;
    public  Transform LowerLimit;

    public Transform RightLimit;
    public Transform LeftLimit;



    // Start is called before the first frame update
    void Start()
    {

        Left = new Rect(0,0, Screen.width/3f, Screen.height *3/4);
        Right = new Rect(Screen.width *2/3f , 0, Screen.width / 3f, Screen.height *3/4);

        Up = new Rect(0, 3/4f * Screen.height, Screen.width, Screen.height/4f);

    }

    Vector3 Get_From_Camera_and_Null_Zed(Vector3 x)
    {
        x = Camera.main.ScreenToWorldPoint(x);
        x.z = 0;
        return x;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (Left.Contains(touch.position))
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Left_First_touch = Get_From_Camera_and_Null_Zed(touch.position);
                        break;

                    case TouchPhase.Moved:
                        Current_left = Get_From_Camera_and_Null_Zed(touch.position);
                        Vector3 diff_y = new Vector3(0, Current_left.y - Left_First_touch.y, 0);



                        if (diff_y.y > 0 && Vector2.Distance(WoodLeft.transform.position, UpperLimit.position) > 0.6f) 
                        {
                            WoodLeft.GetComponent<Rigidbody2D>().MovePosition(WoodLeft.transform.position + diff_y * 30 * Time.deltaTime);

                        }
                        else if (diff_y.y < 0 && Vector2.Distance(WoodLeft.transform.position, LowerLimit.position) > 0.6f)
                        {
                            WoodLeft.GetComponent<Rigidbody2D>().MovePosition(WoodLeft.transform.position + diff_y * 30 * Time.deltaTime);

                        }

                        Left_First_touch = Current_left;

                        break;



                }

                
            }

            else if (Right.Contains(touch.position))
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Right_First_touch = Get_From_Camera_and_Null_Zed(touch.position);
                        break;

                    case TouchPhase.Moved:
                        Current_Right = Get_From_Camera_and_Null_Zed(touch.position);
                        Vector3 diff_y = new Vector3(0, Current_Right.y - Right_First_touch.y, 0);



                        if (diff_y.y > 0 && Vector2.Distance(WoodRight.transform.position, UpperLimit.position) > 0.6f)
                        {
                            WoodRight.GetComponent<Rigidbody2D>().MovePosition(WoodRight.transform.position + diff_y * 30 * Time.deltaTime);

                        }
                        else if (diff_y.y < 0 && Vector2.Distance(WoodRight.transform.position, LowerLimit.position) > 0.6f)
                        {
                            WoodRight.GetComponent<Rigidbody2D>().MovePosition(WoodRight.transform.position + diff_y * 30 * Time.deltaTime);

                        }

                        Right_First_touch = Current_Right;

                        break;



                }
            }

            else if (Up.Contains(touch.position))
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Top_First_Touch = Get_From_Camera_and_Null_Zed(touch.position);
                        break;

                    case TouchPhase.Moved:
                        Current_Top = Get_From_Camera_and_Null_Zed(touch.position);
                        Vector3 diff_x = new Vector3(Current_Top.x - Top_First_Touch.x,0, 0);


                        Debug.Log(Vector2.Distance(WoodMiddle.transform.position, RightLimit.position));
                        if (diff_x.x > 0 && Vector2.Distance(WoodMiddle.transform.position, RightLimit.position) > 0.4f)
                        {
                            WoodMiddle.GetComponent<Rigidbody2D>().MovePosition(WoodMiddle.transform.position + diff_x * 30 * Time.deltaTime);

                        }
                        else if (diff_x.x < 0 && Vector2.Distance(WoodMiddle.transform.position, LeftLimit.position) > 0.4f)
                        {
                            WoodMiddle.GetComponent<Rigidbody2D>().MovePosition(WoodMiddle.transform.position + diff_x * 30 * Time.deltaTime);

                        }

                        Top_First_Touch = Current_Top;

                        break;



                }
            }

        }


    }
}
