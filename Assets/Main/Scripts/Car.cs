using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 240f;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float slowSpeed = 5f;
    [SerializeField] private float boostSpeed = 10f;
    
     void Update()
     { 
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

     void OnCollisionEnter2D(Collision2D other)
     {
         moveSpeed = slowSpeed;
     }

     void OnTriggerEnter2D(Collider2D other)
     {
         if (other.tag == "Boost")
         {
             Debug.Log("You are boosting");
             moveSpeed = boostSpeed;
         }
     }
}
