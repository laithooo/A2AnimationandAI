using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBox : MonoBehaviour
{

    public float boostStrength = 25f;
    public float cameraBackwards = 0.25f;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        SpeedBoost velocity = collider.GetComponent<SpeedBoost>();
        Debug.Log("testing");
        velocity.Boost(boostStrength);

        Vector3 originalPosition = camera.transform.localPosition;
        camera.transform.localPosition += camera.transform.localPosition * cameraBackwards;

    }
}
