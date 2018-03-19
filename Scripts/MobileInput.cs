using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static MobileInput Instance { set; get; }

    private bool //tap, 
    swipeLeft, swipeRight
    // , swipeUp, swipeDown
    ;
    private Vector2 swipeDelta, startTouch;

    //  public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }

    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    //  public bool SwipeUp { get { return swipeUp; } }
    //public bool SwipeDown { get { return swipeDown; } }


    // Use this for initialization
    private void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        //Reset everything to false - read from right to left;
        //tap = 
        swipeLeft = swipeRight
        // = swipeUp = swipeDown 
        = false;


        //Check if there is a touch input at all
        if (Input.touches.Length != 0)
        {
            //Might have multiple touchings,but focus on the first one
            if (Input.touches[0].phase == TouchPhase.Began)
            {
             //  tap = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {//Debug.Log("Swipe");
                startTouch = swipeDelta = Vector2.zero;
            }
        }


        //Calculate distance
        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            if (Input.touches.Length != 0)
            {//Debug.Log("Swipe2");
                swipeDelta = Input.touches[0].position - startTouch;
            }
        }
        //Check if we're beyound the deadzone
        if (swipeDelta.magnitude > 100)
        {//Debug.Log("Swipe3");
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
            /* else
             { //Up or Down
                 //Left or Right
                 if (y < 0)
                 {//Debug.Log("SwipeU");
                     //Down
                     swipeDown = true;
                 }
                 else
                 {  //Up
                     swipeUp = true;
                 }
             }*/
            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
