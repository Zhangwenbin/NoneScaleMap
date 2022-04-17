using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController Instance;
    public delegate void OnHeightChange(float height);
    public event OnHeightChange onHeightEvent;
    public float minHeight;
    public float maxHeight;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        game g = GameObject.FindObjectOfType<game>();
        g.StartCreate();
        if (onHeightEvent!=null)
        {
            onHeightEvent(transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y>minHeight)
                transform.position += transform.forward * Time.deltaTime*speed;
            if (onHeightEvent!=null)
            {
                onHeightEvent(transform.position.y);
            }
           
        }else if (Input.GetKey(KeyCode.DownArrow))
        { 
            if (transform.position.y<maxHeight)
            transform.position -= transform.forward * Time.deltaTime*speed;
            if (onHeightEvent!=null)
            {
                onHeightEvent(transform.position.y);
            }
        }else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * Time.deltaTime*speed;
   
        }else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime*speed;
       
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position -= Vector3.back * Time.deltaTime*speed;
   
        }else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime*speed;
       
        }


    }
}
