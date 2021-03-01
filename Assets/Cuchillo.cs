using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : MonoBehaviour
{
    private Rigidbody2D cuchillo;
    public Transform Padre;
    public Transform Hijo;    
    public GameObject duplicarCuchi;    
    public float Velocidad;
    private Vector3 MoverHacia;   
    private Vector2 fuerzaCuchi;
    

    // Start is called before the first frame update
    void Start()
    {
        cuchillo = GetComponent<Rigidbody2D>();
        
        fuerzaCuchi.x = 0.0f;
        fuerzaCuchi.y = Velocidad * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            cuchillo.AddForce(fuerzaCuchi);
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "tronc")
        {
            Hijo.SetParent(Padre);
            cuchillo.isKinematic = true;
            print("COLISIONO CON TRONCO");
        }
        

    }
}
