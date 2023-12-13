using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    public GameManager _GameManager;
    void Start()
    {
        transform.Translate(Vector3.forward * 3.0f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.GetAxis("Mouse X") < 0)//mouse sola gitmiş olur
            {
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
            }

            if (Input.GetAxis("Mouse X") > 0)//mouse sağa gitmiş olur
            {
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "x2" || other.name == "+3" || other.name == "-4" || other.name == "/2")
        {
            _GameManager.AdamYönetimi(other.name, other.transform);
            Debug.Log("carptı");
        }
    }
}
