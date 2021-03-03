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
    public GameObject eliminarStart;
    public GameObject eliminarEnd;
    private Vector2 fuerzaCuchi;
    private float Velocidad = 30000;    
    private int contador = 1;
    public Transform Padre;
    public Transform Hijo;    
    private Vector3 MoverHacia;
    bool tirarSpace = false;
    public PolygonCollider2D cuchi1;
    public GameObject destruirCuchi;
    private bool colTrasera = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
        cuchillo1 = GetComponent<Rigidbody2D>();
        fuerzaCuchi.x = 0.0f;
        fuerzaCuchi.y = Velocidad * Time.deltaTime;
        MoverHacia = EndPoint.position;
        
        
        
    }

    //-0.328

    // Update is called once per frame
    void Update()
    {
        
        if (tirarSpace == true)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                cuchillo1.AddForce(fuerzaCuchi);

                tirarSpace = false;

            }
            
        }

    }

    private void FixedUpdate()
    {
        if (Cuchillo.transform.position.y > -2.0f && contador <20 && colTrasera == false)
        {
            ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, VelocidadAmover * Time.deltaTime);
            contador++;

        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "tronc")
        {
            Hijo.SetParent(Padre);
            cuchillo1.isKinematic = true;
            cuchi1.isTrigger = true;


        }
        
        if ((col.gameObject.tag == "trasera" && cuchillo1.transform.position.y < -0.200) || (col.gameObject.tag == "trasera" && cuchillo1.transform.position.y > 5.5))
        {
            
            colTrasera = true;
            print("solo con la trasera cuchi 1");
        }
        if (colTrasera == true)
        {
            
            Invoke("destruirCuchillo", 3f);
            
            colTrasera = false;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "tirar")
        {
            Destroy(eliminarStart);
            Destroy(eliminarEnd);
            tirarSpace = true;
        }
        if (col.gameObject.tag == "fuerademapa")
        {
            Invoke("destruirCuchillo", 3f);
        }
    }

    void destruirCuchillo()
    {
        Destroy(gameObject);
    }
}//SI CUCHILLO COLISIONA CON LA PARTE DE ATRAS BORRAR CON UN INVOKE(destuircuchillo,5f)
