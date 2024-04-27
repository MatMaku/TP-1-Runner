using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        GetInput();
    }

    //Si se toca la tecla "R" reseteo el tiempo y vuelvo a cargar la escena para que el juego vuelva a empezar
    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}
 