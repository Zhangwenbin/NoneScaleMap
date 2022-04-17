using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    public GameObject block;
    public int width, length;
    public int bianchang;
    // Start is called before the first frame update
    public void StartCreate()
    {
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                var blocki = GameObject.Instantiate(block);
                blocki.transform.position = new Vector3( bianchang*i, 0, j * bianchang);
                blocki.SetActive(true);
             
            }
        }
        block.SetActive(false);
    }
    
}
