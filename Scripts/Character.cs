﻿using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isDead;

    private const int MAX_SPEED = 30;
    private const float MAX_SCALE = 1f;

    private Vector3 moveVector;
    private Vector3 scaleVector;
    private CharacterController playerController;

    private int coinsCollected;
    private float speed;

    private AudioSource audio;
    public AudioClip coinSound;
    public AudioClip deathSound;
    public AudioClip fishSound;

    // Use this for initialization
    private void Start()
    {
        
        Debug.Log("The volume is: "+SettingsCanvas.volume);
       
        audio = GetComponent<AudioSource>();
        audio.volume = SettingsCanvas.volume;
        //Reference to the player's Character Controler - used for movement.
        playerController = GetComponent<CharacterController>();

        //Reference to the player character Vector3 size - used for scaling
        scaleVector = transform.localScale;

        //Set or reset isDead
        isDead = false;
       
        //Set initial speed
        speed = 10.0f;

        //Set or reset the amount of collected coins
        coinsCollected = 0;
    }

    // Update is called once per frame
    private void Update()
    {
     
        /************************** MOBILE INPUT ***************************/
        //if the player is not dead
        if (!isDead)
        {
            //Slightly increase the speed until not less than the const MAX_SPEED
            if (speed < MAX_SPEED)
            {
                speed += Time.deltaTime;
            }

            //Swipe Left - the furthest left position allowed is -3
            if (MobileInput.Instance.SwipeLeft && transform.localPosition.x > -1)
            {
                //Move
                playerController.Move(new Vector3(-3, 0, 0));

                //Decrease the energy with 3 per swipe
                GetComponent<PlayerEnergy>().LoseEnergy(3f);
            }

            //Swipe Right - the furthest right position allowed is 3
            if (MobileInput.Instance.SwipeRight && transform.localPosition.x < 1)
            {
                //Move
                playerController.Move(new Vector3(3, 0, 0));

                //Decrease the energy with 3 per swipe
                GetComponent<PlayerEnergy>().LoseEnergy(3f);
            }

            moveVector.z = speed;
            playerController.Move(moveVector * Time.deltaTime);
        }


        /************************** KEYBOARD INPUT ***************************/
        //Keyboard input - Only for testing in the Unity editor
        /* 
          if (!isDead)
            {
                if (speed < 25) { speed += Time.deltaTime; }
                moveVector = Vector3.zero; // reset

                //   if (controller.isGrounded)
                //  {
                //     verticalVelocity = -0.5f;
                //}
                //else
                // {
                //   verticalVelocity -= gravity;
                //}
                // X = left and right
                moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
               // Debug.Log(moveVector.x);
                // Y = up and down
                // moveVector.y = verticalVelocity;
                // Z = forward and backward
                moveVector.z = speed;

                playerController.Move(moveVector * Time.deltaTime);
            }
            */
    }

    //If the object doesn't have a trigger activated - call death function
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Death();
        audio.PlayOneShot(deathSound, 1f);
    }


    //If the object has a renderer, then renderer.bounds.size
    //Next best thing would probably be collider.bounds.size
    private void OnTriggerEnter(Collider hit)
    {
        //CompareTag("") is more efficient than tag == ""
        //== is 27% less efficient because it creates a duplicate of the variable and then 
        //has to invoke garbage collector to release the memory

        //Coins
        if (hit.gameObject.CompareTag("Collectable"))
        {
            audio.PlayOneShot(coinSound, 1f);
            GetComponent<Score>().score += 100;
            ++coinsCollected;
        }

        //if is a fish that shouldn't be collided with, take energy
        else if (hit.gameObject.CompareTag("EnemyFish"))
        {
            GetComponent<PlayerEnergy>().LoseEnergy(20f);
            audio.PlayOneShot(fishSound, 1f);
        }

        //add energy, add score, scale
        else if (hit.gameObject.CompareTag("FriendlyFish"))
        {
            audio.PlayOneShot(fishSound, 1f);
            //add energy
            GetComponent<PlayerEnergy>().GainEnergy(20f);

            //increase current score
            GetComponent<Score>().score += 1000;

            //slightly increase character size
            if (scaleVector.x < MAX_SCALE)
            {
                scaleVector.x += 0.05f;
                scaleVector.y += 0.05f;
                scaleVector.z += 0.05f;
                transform.localScale = scaleVector;
            }
        }

        //whatever the hit object is make it invisible - disable it
        hit.gameObject.SetActive(false);
    }

    public void Death()
    {
        Handheld.Vibrate();

        //Keep a variable with the score
        int score = (int)GetComponent<Score>().score;

        //Stop the player movement
        isDead = true;

        //Stop the energy script
        GetComponent<PlayerEnergy>().OutOfEnergy();

        //Stop the score update
        GetComponent<Score>().isDead = true;

        //Save the highscore and the coins
        GetComponent<PlayerData>().Save(coinsCollected, score);
 
        //Show the end of game screen
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);

        //Update the end of game score text
        GameObject.Find("DeathMenu").GetComponent<DeathMenu>().ToggleEndOfGameMenu(score);

        //Hide the energy bar and the score
        GameObject.Find("HUD_Canvas_Energy").SetActive(false);
    }
}
