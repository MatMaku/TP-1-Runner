using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Enemy5 : MonoBehaviour
{
    public static float enemyVelocity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //En el update hace que el enemigo vaya hacia la izquierda y hacia arriba y luego llama a la corrutina OutOfBounds
    void Update()
    {
        rb.AddForce(new Vector3(-enemyVelocity, enemyVelocity/20, 0), ForceMode.Force);
        OutOfBounds();
    }

    //Hace que cuando el objeto este fuera de la pantalla se destruya
    public void OutOfBounds()
    {
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}
