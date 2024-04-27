using System.Collections;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private MeshRenderer m_Renderer;
    private Rigidbody rb;
    public float jumpForce = 10;
    private float initialSize;
    private int i = 0;
    private bool floored;
    private bool parry = false;
    private bool parryCD = true;
    public int cooldown = 2;

    //Defino el tamaño inicial del jugador
    private void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        initialSize = rb.transform.localScale.y;
    }

    //Espero a recibir un comando
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        Jump();
        Duck();
        Parry();
    }

    //Si el jugador esta en contacto con el suelo y toco la tecla "W" hago que el jugador salte impulsandolo para arriba segun jumpForce
    private void Jump()
    {
        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    //Dependiendo de si el jugador esta en contacto con el suelo o no al presionar la tecla "S" hago que el jugador se agache o baje mas rapido si esta en el aire
    private void Duck()
    {
        if (floored)
        {
            if (Input.GetKey(KeyCode.S))
            {
                //Si i(Que es una variable que usamos para saber si el jugador esta agachado o no) es igual a 0 transformo la escala del jugador para que se agache
                if (i == 0)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++;
                }
            }
            else
            {
                //Si la escala del jugador es diferente a la inicial y se dejo de presionar "S" devuelvo al jugador a su escala original
                if (rb.transform.localScale.y != initialSize)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0;
                }
            }
        }
        else
        {
            //Le doy un impulso al jugador hacia abajo para que baje mas rapido
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    //Si el jugador toca el "Space" su personaje se pondra de color amarillo indicando que esta haciendo un parry
    private void Parry()
    {
        if (Input.GetKeyDown(KeyCode.Space) && parryCD)
        {
            m_Renderer.material.color = Color.yellow;
            parry = true;
            parryCD = false;
            StartCoroutine("ParryCD");
            
        }
    }

    //Se queda un segundo en estado de parry y con la variable cooldown definimos dentro de cuanto tiempo podremos volver a hacer parry
    IEnumerator ParryCD()
    {
        yield return new WaitForSeconds(1);
        m_Renderer.material.color = Color.blue;
        parry = false;
        yield return new WaitForSeconds(cooldown);
        parryCD = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Si entro en colisión con un objeto tageado como "Enemy" destruyo al jugador y declaro gameOver como true para que salta de pantalla de derrota en el script Controller_Hud
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Controller_Hud.gameOver = true;
        }

        if (collision.gameObject.CompareTag("Wall enemy") && parry)
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall enemy") && !parry)
        {
            Destroy(this.gameObject);
            Controller_Hud.gameOver = true;
        }

        //Si entro en colisión con un objeto tageado como "Floor" defino la variable floored como true, para saber que el jugador esta en contacto con el suelo
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Si salgo de colisión con un objeto tageado como "Floor" defino la variable floored como false, para saber que el jugador dejó de estar en contacto con el suelo
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = false;
        }
    }
}
