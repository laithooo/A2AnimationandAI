using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator MarioAnimator;
    float speed = 70f;
    float rotatespeed = 5f;
    public Rigidbody rb;
    public float LeanLeftWeight = 0f;
    public float LeanRightWeight = 0f;
    public float currentleanweight;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MarioAnimator = GetComponent<Animator>();
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

        if (Input.GetKey(KeyCode.A))
        {
            LeanLeftWeight = 1f;
            LeanRightWeight = 0f;
            currentleanweight = MarioAnimator.GetFloat("LeanLeftWeight");
            MarioAnimator.SetFloat("LeanLeftWeight", 1f);
            currentleanweight = MarioAnimator.GetFloat("LeanRightWeight");
            MarioAnimator.SetFloat("LeanRightWeight", 0f);


        }


        if (Input.GetKey(KeyCode.D))
        {
            LeanRightWeight = 1f;
            LeanLeftWeight = 0f;
            currentleanweight = MarioAnimator.GetFloat("LeanRightWeight");
            MarioAnimator.SetFloat("LeanRightWeight", 1f);
            currentleanweight = MarioAnimator.GetFloat("LeanLeftWeight");
            MarioAnimator.SetFloat("LeanLeftWeight", 0f);
        }



    }
}
