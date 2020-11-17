using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 2f;
    private Rigidbody2D rigidBody;
    public float jumpForce;
    public bool Pisando;
    public bool Izquierda;
    public bool Derecha;
    public LayerMask pisolayer;
    private int _maxSaltos;
    public int maxSaltos;
    private Vector3 escala;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _maxSaltos = maxSaltos;
        escala = transform.localScale;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            _animator.SetBool("Caminando", true);
        }
        else
        {
            _animator.SetBool("Caminando", false);
        }
        if (Input.GetKey("a"))
        {
            transform.position += Vector3.left * velocidad * Time.deltaTime;
            transform.localScale = new Vector3(escala.x, escala.y, escala.z);
            
        }
        
        if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * velocidad * Time.deltaTime;
            transform.localScale = new Vector3(-escala.x, escala.y, escala.z);
            
        }

        if (!Pisando)
        {
            _animator.SetBool("Saltando", true);
        }
        else
        {
            _animator.SetBool("Saltando", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Pisando)
        {
           
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }       
        else 
        if (Input.GetKeyDown(KeyCode.Space) && !Pisando && maxSaltos > 0)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            maxSaltos--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Izquierda&&!Pisando)
        {
            Vector3 direccion = Vector3.up + Vector3.right;
            rigidBody.AddForce(direccion * jumpForce, ForceMode2D.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Derecha && !Pisando)
        {
            Vector3 direccion = Vector3.up + Vector3.left;
            rigidBody.AddForce(direccion * jumpForce, ForceMode2D.Impulse);
        }



















        //if (Input.GetKey("w"))
        //{
        //    transform.position += Vector3.up * velocidad * Time.deltaTime;
        //}
        //if (Input.GetKey("s"))
        //{
        //    transform.position += Vector3.down * velocidad * Time.deltaTime;
        //}







    }
    private void FixedUpdate()
    {
        DetectorPiso();
    }
    public void DetectorPiso()
    {
        Pisando = false;
        RaycastHit2D ColisionAbajo;
        ColisionAbajo = Physics2D.Raycast(transform.position, Vector2.down, 1f,pisolayer.value);
        
        if (ColisionAbajo.collider !=null)
        {
            
            if (ColisionAbajo.collider.gameObject.CompareTag("Piso"))
            {
                Pisando = true;
                maxSaltos = _maxSaltos;
            }
        }

        Izquierda = false;
        RaycastHit2D ColisionIzquiera;
        ColisionIzquiera = Physics2D.Raycast(transform.position, Vector2.left, 0.8f, pisolayer.value);

        if (ColisionIzquiera.collider != null)
        {
            Debug.Log("Izquierda");
            if (ColisionIzquiera.collider.gameObject.CompareTag("Piso"))
            {
                Izquierda = true;
            }
        }

        Derecha = false;
        RaycastHit2D ColisionDerecha;
        ColisionDerecha = Physics2D.Raycast(transform.position, -Vector2.left, 0.8f, pisolayer.value);

        if (ColisionDerecha.collider != null)
        {
            Debug.Log("Derecha");
            if (ColisionDerecha.collider.gameObject.CompareTag("Piso"))
            {
                Derecha = true;
            }
        }



    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Q)&&collision.CompareTag("Item"))
        {
            PlayerPrefs.SetString("Oro", "Si");
            Debug.Log("Oro");
        }

    }
}
