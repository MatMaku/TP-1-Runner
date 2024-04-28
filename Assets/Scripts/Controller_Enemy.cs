using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public static float enemyVelocity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //En el update hace que el enemigo vaya hacia la izquierda y luego llama a la corrutina OutOfBounds
    void Update()
    {
        rb.AddForce(new Vector3(-enemyVelocity, 0, 0), ForceMode.Force);
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

    //Esta corrutina esta en el caso de que el objeto creado sea un power up, ya que usan el mismo script de movimiento, y que entre en contacto con un enemigo
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Wall enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
