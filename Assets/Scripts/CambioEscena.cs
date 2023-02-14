using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public void cambioEscenaJuego()
    {
        SceneManager.LoadScene("Juego");
    }
    public void cambioEscenaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void cambioEscenaOpciones()
    {
        SceneManager.LoadScene("Opciones");
    }
}
