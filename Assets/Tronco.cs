using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tronco : MonoBehaviour {

    private float Velocidad = 50;
    private float z;
    private Rigidbody2D tronco;

    private Vector3 cuchillo;
    
    int contador = 0;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        tronco = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Luego de 5 segundos invoca la funcion GIRO FALSE
        contador++;
        z += Time.deltaTime * Velocidad;
        transform.rotation = Quaternion.Euler(0, 0, z);
       
        if (contador > 2000)
        {
            Velocidad = 300;
        }
        if (contador > 4000)
        {
            Velocidad = Velocidad - 300;
        }
        if (Velocidad == 0)
        {
            Velocidad = -50;
        }

        if (tronco.GetComponentInChildren<Cuchillo>())
        {
            cuchillo = tronco.GetComponentInChildren<Cuchillo>().transform.position;
            cuchillo.y = tronco.transform.position.y;
            cuchillo.x = tronco.transform.position.x;
        }
    }
        
    
}
