///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: ButtonNumber.cs
///////////////////////////////////////////

using System;
using UnityEngine;
using UnityEngine.UI;


public class ButtonNumber : MonoBehaviour
{ 
    /// <summary>
    /// Corresponde al valor de cada botón.
    /// </summary>
    public string text;
  
    /// <summary>
    /// Corresponde al objeto Text del panel de configuración.
    /// </summary>
    public Text ipAdress;

    // Use this for initialization
    void Start()
    {
        // Se asigna el texto asignado al texto del botón
        GetComponentInChildren<Text>().text = text;
    }

    /// <summary>
    /// Es llamado al pulsar en cada botón del teclado.
    /// <remarks>
    /// Al pulsar en un botón del teclado se comprueba que si son "back" o "clear", efectuen sus acciones, sino es así se asignará el número del campo text al campo de la ipaddres.
    /// </remarks>
    /// </summary>
    public void Click()
    {
        if (text.Equals("Back") && !String.IsNullOrEmpty(ipAdress.text))
        {
            ipAdress.text = ipAdress.text.Remove(ipAdress.text.Length - 1);
        }

        else if (text.Equals("Clear") && !String.IsNullOrEmpty(ipAdress.text))
        {
            ipAdress.text = "";
        }
        else if (!text.Equals("Clear") && !text.Equals("Back"))
        {
            ipAdress.text += text;
        }
    }
}