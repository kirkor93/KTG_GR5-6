using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float SideSpeed = 5.0f, ForwardSpeed = 5.0f;
    public GUIStyle invisibleButton;
    public GameObject Player;
    Vector3 newPos;
    public float[] Lanes = new float[3];
    int CurrentLane, LastLane;
    bool SwitchingLanes, JumpReady, Jump;
    bool ButtonLeft, ButtonRight;
    bool Alive = true;
	public float deathDelay = 2.0f;

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
            if (GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height), "Left", invisibleButton))
            {
                ButtonLeft = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), "Right", invisibleButton))
            {
                ButtonRight = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ramp" && !Jump)
        {
            Debug.Log("Collision with Ramp, jump.");
            if (JumpReady)
            {
                JumpReady = false;
                Jump = true;
                StartCoroutine("WaitForJump");
            }
            else
            {
                StartCoroutine("Death");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive)
        {
            // Forward movement
            Player.transform.Translate(0, 0, -ForwardSpeed * Time.deltaTime);

            // Lanes switching mechanism
            if (SwitchingLanes)
            {
                float step = SideSpeed * Time.deltaTime;

                newPos.y = transform.position.y;
                newPos.z = transform.position.z;

                transform.position = Vector3.MoveTowards(transform.position, newPos, step);
                transform.Rotate(transform.forward, 2 * (transform.position.x - newPos.x + (Lanes[CurrentLane] - Lanes[LastLane]) / 2));

                if (transform.position.x == newPos.x)
                {
                    transform.rotation = Quaternion.identity;
                    SwitchingLanes = false;
                }
            }
            else
            {
                JumpReady = ButtonLeft = ButtonRight = false;
                int i = 0;
                while (i < Input.touchCount)
                {
                    if (Input.GetTouch(i).position.x > Screen.width / 2)
                    {
                        ButtonRight = true;
                    }
                    else
                    {
                        ButtonLeft = true;
                    }
                    i++;
                }

                // Buttons handling
                if (ButtonLeft && ButtonRight && !Jump)
                {
                    JumpReady = true;
                }
                else if (ButtonLeft && CurrentLane != 2 && !Jump)
                {
                    LastLane = CurrentLane++;
                    newPos.x = Lanes[CurrentLane];
                    SwitchingLanes = true;
                }
                else if (ButtonRight && CurrentLane != 0 && !Jump)
                {
                    LastLane = CurrentLane--;
                    newPos.x = Lanes[CurrentLane];
                    SwitchingLanes = true;
                }
            }
        }
    }

	IEnumerator Death()
    {    
		yield return new WaitForSeconds(deathDelay);
        Alive = false;
		Debug.Log ("Umalem");
	}

    IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(2);
        Jump = false;
    }
}
