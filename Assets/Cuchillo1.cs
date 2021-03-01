using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo1 : MonoBehaviour
{
    public GameObject Cuchillo;
    private Rigidbody2D cuchillo1;
    public GameObject ObjetoAmover;
    public Transform StartPoint;
    public Transform EndPoint;
    public float VelocidadAmover;
    private Vector2 fuerzaCuchi;
    private float Velocidad = 30000;
    public GameObject BorrarStart;
    public GameObject BorrarEnd;
    private int contador = 1;
    public Transform Padre;
    public Transform Hijo;    
    private Vector3 MoverHacia;

    // Start is called before the first frame update
    void Start()
    {
        cuchillo1 = GetComponent<Rigidbody2D>();
        fuerzaCuchi.x = 0.0f;
        fuerzaCuchi.y = Velocidad * Time.deltaTime;

        MoverHacia = EndPoint.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Cuchillo.transform.position.y > -2.0f && contador < 50 )
        {
            ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, VelocidadAmover*Time.deltaTime);
            contador++;

        }
        print(cuchillo1.transform.position.y);
        if(cuchillo1.transform.position.y == -2.51f)
        {
            Destroy(BorrarEnd);
            Destroy(BorrarStart);

            if (Input.GetKeyDown(KeyCode.Space))
            {

                cuchillo1.AddForce(fuerzaCuchi);

            }
        }
        

    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "tronc")
        {
            Hijo.SetParent(Padre);
            cuchillo1.isKinematic = true;
            
            print("COLISIONO CON TRONCO");
        }


    }


}
