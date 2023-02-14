using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Texto : MonoBehaviour
{
    public Text Menu;
    public Text Iniciar;
    public Text Opciones;
    public Text Salir;
    public int idioma;
    GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Canvas");
        CargarIdioma();
        CargarTextoIdioma();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CargarIdioma()
    {
        manager.GetComponent<DatosCompartidos>().CargarIdioma();
        idioma = manager.GetComponent<DatosCompartidos>().Idioma;
    }
    public void GuardarIdioma(int idi)
    {
        idioma = idi;
        manager.GetComponent<DatosCompartidos>().GuardarIdioma(idi);
        CargarTextoIdioma();
    }
    private void CargarTextoIdioma()
    {
        if(idioma == 1)
        {
            Menu.text = "";
            Iniciar.text = "";
            Opciones.text = "";
            Salir.text = "";
        }
        else //if (idioma == 2)
        {
            Menu.text = "";
            Iniciar.text = "";
            Opciones.text = "";
            Salir.text = "";
        }
    }
}
