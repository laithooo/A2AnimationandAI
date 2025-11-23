using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 70f;
    float rotatespeed = 5f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moving = new Vector3(vertical, 0, -horizontal);
        
        transform.position += moving * speed * Time.deltaTime;

        if ( moving != Vector3.zero)
        {
            Quaternion targetrotate = Quaternion.LookRotation(moving);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetrotate, rotatespeed * Time.deltaTime);
        }


    }
}
