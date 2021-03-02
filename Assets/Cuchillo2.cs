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
    public float VelocidadAmover;
    private Vector2 fuerzaCuchi;
    private float Velocidad = 30000;    
    private int contador = 1;
    public Transform Padre;
    public Transform Hijo;
    private Vector3 MoverHacia;
    bool tirarSpace = false;
    public BoxCollider2D cuchi2;
    public GameObject destruirCuchi;    

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
        if (Cuchillo1.transform.position.y > -2.0f && contador < 20)
        {
            ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, VelocidadAmover * Time.deltaTime);
            contador++;

        }
        print(contador);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "tronc")
        {
            Hijo.SetParent(Padre);
            cuchillo2.isKinematic = true;
            cuchi2.isTrigger = true;
            

        }
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "tirar")
        {
            tirarSpace = true;
        }
    }
    
    void destruircuchillo()
    {
        Destroy(gameObject);
    }

    //SI CUCHILLO COLISIONA CON LA PARTE DE ATRAS BORRAR CON UN INVOKE(destuircuchillo,5f)
}