using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo2 : MonoBehaviour
{
    public GameObject Cuchillo1;
    private Rigidbody2D cuchillo2;
    public GameObject ObjetoAmover;
    public Transform StartPoint;
    public Transform EndPoint;
    public GameObject eliminarStart;
    public GameObject eliminarEnd;
    public float VelocidadAmover;
    private Vector2 fuerzaCuchi;
    private float Velocidad = 30000;    
    private int contador = 1;
    public Transform Padre;
    public Transform Hijo;
    private Vector3 MoverHacia;
    bool tirarSpace = false;
    public PolygonCollider2D cuchi2;
    public GameObject destruirCuchi;
    bool colTrasera = false;

    // Start is called before the first frame update
    void Start()
    {
        cuchillo2 = GetComponent<Rigidbody2D>();
        fuerzaCuchi.x = 0.0f;
        fuerzaCuchi.y = Velocidad * Time.deltaTime;
        MoverHacia = EndPoint.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (tirarSpace == true)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                cuchillo2.AddForce(fuerzaCuchi);

                tirarSpace = false;
                

            }

        }

    }

    private void FixedUpdate()
    {
        if (Cuchillo1.transform.position.y > -2.0f && contador < 20 && colTrasera == false)
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
            cuchillo2.isKinematic = true;
            cuchi2.isTrigger = true;          

        }
        if ((col.gameObject.tag == "traseracuchi1" && cuchillo2.transform.position.y < -0.200) || (col.gameObject.tag == "traseracuchi1" && cuchillo2.transform.position.y > 5.5))
        {
            
            colTrasera = true;
            print("solo con la trasera cuchi2");
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

}