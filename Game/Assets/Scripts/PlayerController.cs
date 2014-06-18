using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    static public Vector3 playerPos;
    public static PlayerController instance = null;
    public ParticleSystem explo;
    public float SideSpeed = 5.0f, ForwardSpeed = 5.0f;
    public GUIStyle invisibleButton;
    public GameObject Player;
    Quaternion cameraRotationDefault;
    Vector3 newPos;
    public float[] Lanes = new float[3];
    int CurrentLane, LastLane;
    bool SwitchingLanes, JumpReady, Jump;
    bool ButtonLeft, ButtonRight;
    bool Alive = true;
    bool Drunk = false;
    float drunkTime;
    float drunkAngle;
	public float deathDelay = 2.0f;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        CurrentLane = 1;
        LastLane = CurrentLane;
        SwitchingLanes = false;
        JumpReady = false;
        cameraRotationDefault = Camera.main.transform.rotation;
    }

    void OnCollisionEnter(Collision other)
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
				if (Alive) {
						// Forward movement
						Player.transform.Translate (0, 0, -ForwardSpeed * Time.deltaTime);
						if (Drunk) {
								drunkTime -= Time.deltaTime;
								Camera.main.transform.Rotate (transform.forward, drunkAngle * Time.deltaTime);
								if (drunkTime <= 0) {
										Drunk = false;
										Camera.main.transform.rotation = cameraRotationDefault;
								}
						}

						playerPos.x = transform.position.x;
						playerPos.y = transform.position.y;
						playerPos.z = Player.transform.position.z;

						//Lanes switching mechanism
						if (SwitchingLanes) {
								float step = SideSpeed * Time.deltaTime;

								newPos.y = transform.position.y;
								newPos.z = transform.position.z;

								transform.position = Vector3.MoveTowards (transform.position, newPos, step);
								transform.Rotate (transform.forward, 2 * (transform.position.x - newPos.x + (Lanes [CurrentLane] - Lanes [LastLane]) / 2));

								if (transform.position.x == newPos.x) {
										transform.rotation = Quaternion.identity;
										SwitchingLanes = false;

						}
				
				//newPos = new Vector3(CurrentLane*2.5f,0.0f,transform.position.z);
				//transform.position = Vector3.MoveTowards (transform.position, newPos, 5.0f);
						} else {
								JumpReady = ButtonLeft = ButtonRight = false;
								int i = 0;
								while (i < Input.touchCount) {
										if (Input.GetTouch (i).position.x > Screen.width / 2) {
												ButtonRight = true;
										} else {
												ButtonLeft = true;
										}
										i++;
								}

								if (Input.GetKey (KeyCode.A)) {
										ButtonLeft = true;
								}

								if (Input.GetKey (KeyCode.D)) {
										ButtonRight = true;
								}

								// Buttons handling
								if (!Jump) {
										if (ButtonLeft && ButtonRight) {
												JumpReady = true;
										} else if (ButtonLeft && CurrentLane != 2) {
												LastLane = CurrentLane++;
												newPos.x = Lanes [CurrentLane];
												SwitchingLanes = true;
										} else if (ButtonRight && CurrentLane != 0) {
												LastLane = CurrentLane--;
												newPos.x = Lanes [CurrentLane];
												SwitchingLanes = true;
										}
								}
						}
				}
		}

    public void Smoke()
    {
        explo.Play();
    }

	IEnumerator Death()
    {    
		yield return new WaitForSeconds(deathDelay);
        Alive = false;
    }

    IEnumerator WhiskeyInAJar(float WhiskeyPowwa)
    {
        Drunk = true;
        drunkTime = WhiskeyPowwa;
        drunkAngle = 360.0f / WhiskeyPowwa;
        yield return null;
    }

    IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(1);
        Jump = false;
    }
}
