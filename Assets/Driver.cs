using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Define variable
    [SerializeField] float SteerSpeed = 150f;
    [SerializeField] float MoveSpeed = 10f;
    [SerializeField] float MoveSlow = 5f;
    [SerializeField] float MoveFast = 15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * SteerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        MoveSpeed = MoveSlow;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            MoveSpeed = MoveFast;
        }
        else if (other.tag == "Customer")
        {
            MoveSpeed = (MoveFast + MoveSlow) / 2;
        }
    }
}
