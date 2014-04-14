﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float SideSpeed;
    public GUIStyle invisibleButton;
    Vector3 newPos;
    public float[] Lanes = new float[3];
    int CurrentLane, LastLane;
    bool SwitchingLanes, JumpReady, Jump;
    bool ButtonLeft, ButtonRight;

    // Use this for initialization
    void Start()
    {
        CurrentLane = 1;
        LastLane = CurrentLane;
        SwitchingLanes = false;
        JumpReady = false;
    }

    void OnGUI()
    {
        ButtonLeft = ButtonRight = false;
        if (!SwitchingLanes)
        {
            if (GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height), "Left", invisibleButton) && CurrentLane != 2)
            {
                ButtonLeft = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), "Right", invisibleButton) && CurrentLane != 0)
            {
                ButtonRight = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ramp")
        {
            Debug.Log("Collision with Ramp, jump.");
            if (JumpReady)
            {
                JumpReady = false;
                Jump = true;
            }
            else
            {
                // Die.
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SwitchingLanes)
        {
            float step = SideSpeed * Time.deltaTime;

			newPos.y = transform.position.y;
			newPos.z = transform.position.z;

            transform.position = Vector3.MoveTowards(transform.position, newPos, step);
            transform.Rotate(transform.forward, 2 * (transform.position.x - newPos.x + (Lanes[CurrentLane]-Lanes[LastLane]) / 2));

            if (transform.position.x == newPos.x)
            {
                transform.rotation = Quaternion.identity;
                SwitchingLanes = false;
            }
        }

        if(ButtonLeft && ButtonRight)
        {
            JumpReady = true;
        }
        else if(ButtonLeft && CurrentLane != 2)
        {
            LastLane = CurrentLane++;
            newPos.x = Lanes[CurrentLane];
            SwitchingLanes = true;
        }
        else if(ButtonRight && CurrentLane != 0)
        {
            LastLane = CurrentLane--;
            newPos.x = Lanes[CurrentLane];
            SwitchingLanes = true;
        }

    }
}
