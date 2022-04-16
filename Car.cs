using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Car : MonoBehaviour
{
    //editable fields in engine
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSec = 0.2f;
    [SerializeField] private float steerSpeed = 200f;

    private int steerValue;
    private bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        //makes car go faster the longer you survive
        // * Time.deltaTime allows all mobile users to have same framerate (no disadvantage)
        speed += speedGainPerSec  * Time.deltaTime;

        //steering the car
        transform.Rotate(0f, steerValue * steerSpeed * Time.deltaTime, 0f);

        //moves car object forward at x times speed per frame and it
        transform.Translate(Vector3.forward * speed * Time.deltaTime);    

        
      
    }

    //allows user to control steering of car
    public void Steer(int value) 
    {
        steerValue = value;
    }

    //obtsacle collider
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }  

    }
}
