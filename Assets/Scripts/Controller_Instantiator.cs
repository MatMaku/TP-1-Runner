using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    //Declaro enemies que es una lista donde voy a tener todos los prefabs de los enemigos
    //Declaro instantiatePos que es donde van a spawnear los enemigos y la posición de mi instanciador
    //Declaro respawningTimer que va a ser un timer que cuando llegue a 0 se van a empezar a mover los enemigos
    public List<GameObject> enemies;
    public GameObject instantiatePos;
    public float respawningTimer;
    private float time = 0;

    //En Stard defino la velocidad que van a tener los enemigos en el script Controller_Enemy
    void Start()
    {
        Controller_Enemy.enemyVelocity = 2;
    }

    //En el update voy a estar llamando constantemente a las corrutinas SpawnEnemies y ChangeVelocity
    void Update()
    {
        SpawnEnemies();
        ChangeVelocity();
    }

    //En ChangeVelocity hago que los enemigos se vuelvan mas rapidos segun cuanto tiempo se lleve jugado
    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
    }

    //En SpawnEnemies voy actualizando respawningTimer hasta que llegue a 0, cuando llegue a 0 creo un nuevo enemigo aleatorio de la lista de enemigos y reseteo respawningTimer
    private void SpawnEnemies()
    {
        respawningTimer -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], instantiatePos.transform);
            respawningTimer = UnityEngine.Random.Range(2, 6);
        }
    }
}
