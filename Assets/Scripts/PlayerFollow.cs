using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform playerPos;
    public Rigidbody2D playerRb;
    private Transform camPos;
    public float lerpSpeed = 3.5f;
    public float yOffset = 2.5f;
    public float upOffset = 2.5f;
    public float downOffset = 7.5f;

    private float stillTimeCounter;
    public float stillTime = 0.75f;

    private void Awake()
    {
        camPos = gameObject.transform;
    }

    private void FixedUpdate()
    {
        if(playerRb.velocity == Vector2.zero)
        {
            stillTimeCounter -= Time.deltaTime;
        }
        else
        {
            stillTimeCounter = stillTime;
        }

        if(stillTimeCounter <= 0)
        {
            switch (Input.GetAxisRaw("Vertical"))
            {
                case 1:
                    camPos.position = new Vector3(Mathf.Lerp(camPos.position.x, playerPos.position.x, lerpSpeed * Time.smoothDeltaTime), Mathf.Lerp(camPos.position.y, playerPos.position.y + yOffset + upOffset, lerpSpeed * Time.smoothDeltaTime), -10);
                    break;

                case -1:
                    camPos.position = new Vector3(Mathf.Lerp(camPos.position.x, playerPos.position.x, lerpSpeed * Time.smoothDeltaTime), Mathf.Lerp(camPos.position.y, playerPos.position.y + yOffset - downOffset, lerpSpeed * Time.smoothDeltaTime), -10);
                    break;
                
                default:
                    camPos.position = new Vector3(Mathf.Lerp(camPos.position.x, playerPos.position.x, lerpSpeed * Time.smoothDeltaTime), Mathf.Lerp(camPos.position.y, playerPos.position.y + yOffset, lerpSpeed * Time.smoothDeltaTime), -10);
                    break;
            }
        }
        else
        {
            camPos.position = new Vector3(Mathf.Lerp(camPos.position.x, playerPos.position.x, lerpSpeed * Time.smoothDeltaTime), Mathf.Lerp(camPos.position.y, playerPos.position.y + yOffset, lerpSpeed * Time.smoothDeltaTime), -10);
        }
    }
}
