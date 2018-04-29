using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static MobileInput Instance { set; get; }

    private bool swipeLeft, swipeRight;
    private Vector2 swipeDelta, startTouch;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }


    // Use this for initialization
    private void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        swipeLeft = swipeRight = false;

        //Check if there is a touch input at all
        if (Input.touches.Length != 0)
        {
            //Might have multiple touchings,but focus on the first one
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }
        }


        //Calculate distance
        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
        }
        //Check if we're beyound the deadzone
        if (swipeDelta.magnitude > 100)
        {
            //This is a confirmed swipe
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            //might have a negative value if going left or down
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                {
                    //Left
                    swipeLeft = true;
                }
                else
                {
                    //Right
                    swipeRight = true;
                }
            }
 
            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
