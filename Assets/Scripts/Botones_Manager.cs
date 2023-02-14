using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Botones_Manager : MonoBehaviour
{
    GameObject Manager;
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BotonJugar()
    {
        Manager.GetComponent<CambioEscena>().cambioEscenaJuego();
    }
    public void BotonMenu()
    {
        Manager.GetComponent<CambioEscena>().cambioEscenaMenu();
    }
    public void BotonSalir()
    {
        Application.Quit();
    }
    public void BotonOpciones()
    {
        Manager.GetComponent<CambioEscena>().cambioEscenaOpciones();
    }
    public void BotonMando()
    {
        Manager.GetComponent<DatosCompartidos>().GuardarConfigContoles(2);
    }
    public void BotonTeclado()
    {
        Manager.GetComponent<DatosCompartidos>().GuardarConfigContoles(1);
    }
    public void cambiarVolumen(float vol)
    {
        Manager.GetComponent<DatosCompartidos>().guardarVolumen(vol);
    }
}
