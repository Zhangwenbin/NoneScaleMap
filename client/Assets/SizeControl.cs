using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeControl : MonoBehaviour
{
    private Dictionary<GameObject, Vector3> scales;
    // Start is called before the first frame update
    void Start()
    {

        scales = new Dictionary<GameObject, Vector3>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var child2 = transform.GetChild(i);
    
            scales.Add(child2.gameObject,child2.localScale);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child2 = transform.GetChild(i);

            child2.localScale=scales[child2.gameObject]*Camera.main.transform.position.y/10;
            
        }
    }
}
