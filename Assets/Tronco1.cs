using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tronco1 : MonoBehaviour
{
    public GameObject tronco; 

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        transform.rotation = tronco.transform.rotation;
      
    }


}