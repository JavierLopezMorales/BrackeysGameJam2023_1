using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosCompartidos : MonoBehaviour
{
    public int Idioma;
    public int Mando;
    public float Volumen;
    public void CargarIdioma()
    {
        Idioma = PlayerPrefs.GetInt("Idioma",1);
    }
    public void GuardarIdioma(int idi)
    {
        PlayerPrefs.SetInt("Idioma", idi);
    }
    public void CargarConfigControles()
    {
        Mando = PlayerPrefs.GetInt("Config", 1);
    }
    public void GuardarConfigContoles(int Con)
    {
        PlayerPrefs.SetInt("Config", Con);
    }
    public void CargarVolumen()
    {
        Volumen = PlayerPrefs.GetFloat("Volumen", 1);
    }
    public void guardarVolumen(float vol)
    {
        PlayerPrefs.SetFloat("Volumen", vol);
    }
}
