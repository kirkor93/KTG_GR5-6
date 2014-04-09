using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float SideSpeed;
    public float SideOffset;
    public GUIStyle invisibleButton;
    Vector3 newPos;
    int CurrentLane;
    int SideDirection;
    bool SwitchingLanes;

    // Use this for initialization
    void Start()
    {
        CurrentLane = 0;
        SwitchingLanes = false;
    }

    void OnGUI()
    {
        if (!SwitchingLanes)
        {
            if (GUI.Button(new Rect(0, 0, Screen.width / 2, Screen.height), "Left", invisibleButton) && CurrentLane != 1)
            {
                CurrentLane++;
                SideDirection = 1;
                newPos.x = transform.position.x + SideOffset;

                SwitchingLanes = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), "Right", invisibleButton) && CurrentLane != -1)
            {
                CurrentLane--;
                SideDirection = -1;
                newPos.x = transform.position.x - SideOffset;
                //newPos.y = transform.position.y;
                //newPos.z = transform.position.z;
                SwitchingLanes = true;
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
            transform.Rotate(transform.forward, 2 * (transform.position.x - newPos.x + SideDirection * SideOffset / 2));

            if (transform.position.x == newPos.x)
            {
                transform.rotation = Quaternion.identity;
                SwitchingLanes = false;
            }
        }
        else
        {

            //Just for testing, later touch input
            /*
             * We have invisible buttons to change lines so this is unnecessary

			if (Input.GetKey(KeyCode.D) && CurrentLane != -1)
            {
                CurrentLane--;
                SideDirection = -1;
                newPos.x = transform.position.x - SideOffset;
                newPos.y = transform.position.y;
                newPos.z = transform.position.z;
                SwitchingLanes = true;
            }
            else if (Input.GetKey(KeyCode.A) && CurrentLane != 1)
            {
                CurrentLane++;
                SideDirection = 1;
                newPos.x = transform.position.x + SideOffset;
                newPos.y = transform.position.y;
                newPos.z = transform.position.z;
                SwitchingLanes = true;
            }
            */
        }
    }
}
