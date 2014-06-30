using UnityEngine;
using System.Collections;

public class DeathScreenScript : MonoBehaviour
{

    private float timer = 0.0f;
    public float RestartCooldown = 5.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > RestartCooldown)
        {
            Application.LoadLevel("WelcomeScreen");
        }
    }
}