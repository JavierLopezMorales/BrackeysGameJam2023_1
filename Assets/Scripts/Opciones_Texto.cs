using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opciones_Texto : MonoBehaviour
{
    public Text opciones;
    public Text Mando;
    public Text Teclado;
    public Text SelecMod;
    public Text Vol;
    public int idioma;
    GameObject manager;
    public Text Salir;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Canvas");
        manager.GetComponent<DatosCompartidos>().CargarVolumen();
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
        if (idioma == 1)
        {
            opciones.text = "";
            Mando.text = "";
            Teclado.text = "";
            SelecMod.text = "";
            Vol.text = "";
            Salir.text = "";
        }
        else //if (idioma == 2)
        {
            opciones.text = "";
            Mando.text = "";
            Teclado.text = "";
            SelecMod.text = "";
            Vol.text = "";
            Salir.text = "";
        }
    }
}
