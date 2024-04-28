using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator_PowerUp : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject instantiatePos;
    public float respawningTimer;
    private float time = 0;

    //En Start defino la velocidad que van a tener los enemigos en el script Controller_Enemy
    void Start()
    {
        Controller_Enemy.enemyVelocity = 2;
    }

    //En el update voy a estar llamando constantemente a las corrutinas SpawnPowerUp y ChangeVelocity
    void Update()
    {
        SpawnPowerUp();
        ChangeVelocity();
    }

    //En ChangeVelocity hago que los power ups se vuelvan mas rapidos segun cuanto tiempo se lleve jugado(Mas que nada para que los power ups y los enemigos no colisionen)
    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
        Controller_Enemy5.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
    }

    //Voy actualizando respawningTimer hasta que llegue a 0, cuando llegue a 0 creo un nuevo power up y reseteo respawningTimer
    private void SpawnPowerUp()
    {
        respawningTimer -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            Instantiate(powerUp, instantiatePos.transform);
            respawningTimer = 10;
        }
    }
}
