using System;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    //Defino las variables gameOver para saber si el jugador perdio o no y la variable distance para llevar una cuenta de la distancia recorrida
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    private float distance = 0;

    //En el start redefino las variables anteriores, para que se reinicien en cada reseteo de partida y hago que se muestren en los textos del canvas
    void Start()
    {
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString();
        gameOverText.gameObject.SetActive(false);
    }

    //En el update dependiendo de la variable gameOver muestro la pantalla de derrota o actualizo la distancia
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over \n Total Distance: " + Math.Round(distance,0).ToString();
            gameOverText.gameObject.SetActive(true);
        }
        else
        {
            distance += Time.deltaTime;
            distanceText.text = Math.Round(distance, 0).ToString();
        }
    }
}
