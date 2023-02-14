using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolManager : MonoBehaviour
{
    GameObject Manager;
    public Text Volumen;
    
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Canvas");
        cargarVolumen();
        Texto();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cargarVolumen()
    {
        Manager.GetComponent<DatosCompartidos>().CargarVolumen();
        this.GetComponent<Slider>().value = Manager.GetComponent<DatosCompartidos>().Volumen;
    }
    public void GuardarVolumen()
    {
        Manager.GetComponent<DatosCompartidos>().guardarVolumen(this.GetComponent<Slider>().value);
    }
    public void Texto()
    {
        float aux = this.GetComponent<Slider>().value * 100;
        Volumen.text = aux.ToString("0");
    }
}
