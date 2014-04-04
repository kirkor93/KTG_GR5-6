using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float SideSpeed;
    public float SideOffset;
    Vector3 newPos;
    int CurrentLane;
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
            newPos.x = SideOffset * CurrentLane;
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = Vector3.MoveTowards(transform.position, newPos, step);
            if (transform.position == newPos)
            {
                SwitchingLanes = false;
            }
        }
        else
        {
            // Just for testing, later touch input
            if (Input.GetKey(KeyCode.D))
            {
                if (CurrentLane != -1) CurrentLane--;
                SwitchingLanes = true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (CurrentLane != 1) CurrentLane++;
                SwitchingLanes = true;
            }
        }
	}
}
