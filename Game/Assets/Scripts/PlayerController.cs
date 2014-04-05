using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float SideSpeed;
    public float SideOffset;
    Vector3 newPos;
    int CurrentLane;
    int SideDirection;
    bool SwitchingLanes;

	// Use this for initialization
	void Start () {
        CurrentLane = 0;
        SwitchingLanes = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (SwitchingLanes)
        {
            float step = SideSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, newPos, step);
            transform.Rotate(transform.forward, 2*(transform.position.x - newPos.x + SideDirection * SideOffset/2) );
            
            if (transform.position == newPos)
            {
                transform.rotation = Quaternion.identity;
                SwitchingLanes = false;
            }
        }
        else
        {
            // Just for testing, later touch input
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
        }
	}
}
