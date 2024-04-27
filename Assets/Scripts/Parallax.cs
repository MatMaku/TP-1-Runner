using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    private float length, startPos;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (Controller_Hud.gameOver == false)
        {
            //Hago que el objeto(En este caso las imagenes del fondo) se muevan segun la variable parallaxEffect
            transform.position = new Vector3(transform.position.x - parallaxEffect + 0.5f, transform.position.y, transform.position.z);
            //Si el objeto se sale del parametro(En este caso cuando se va de la pantalla) lo posiciono del otro lado de la pantalla
            if (transform.localPosition.x < -20)
            {
                transform.localPosition = new Vector3(20, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }
}
