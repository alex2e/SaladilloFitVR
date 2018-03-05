///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: SaveDni.cs
///////////////////////////////////////////

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveDni : MonoBehaviour
{
    /// <summary>
    /// Objeto con el dni introducido por el usuario.
    /// </summary>
    public Text dniclient;

    /// <summary>
    /// Panel de bienvenida del usuario.
    /// </summary>
    public Text welcome;

    /// <summary>
    /// Panel de training del usuario.
    /// </summary>
    public GameObject training;

    /// <summary>
    /// Panel detail del usuario.
    /// </summary>
    public GameObject detail;

    /// <summary>
    /// Método que se ejecuta cuando se pulsa el boton save.
    /// </summary>
    /// <remarks>
    /// Obtiene el dni introducido por el usuario  y ejecuta una corrutina.
    /// </remarks>
    public void Click()
    {
        // Se obtiene el dni introducida por el usuario
        GameManager.dniclient = dniclient.GetComponent<Text>().text;
        GetClientName();
        // Se elimina los ejercicios
        foreach (Transform child in detail.transform)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Método que se ejecuta en el click.
    /// <remarks>
    /// Este método ejecuta una corrutina que pide a la api el nombre del usuario enviadole un dni, la respuesta será guardada a nivel de proyecto y en caso de respuesta afirmativa se saludará.
    /// </remarks>
    /// </summary>
    private void GetClientName()
    {
        StartCoroutine(GetClientWebApi());
    }


    IEnumerator GetClientWebApi()
    {
        //Se crea la peticion a la web api
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_CLIENT, GameManager.ipaddress,
                GameManager.dniclient))))
        {
            //Envia la peticion a la web api y espera la respuesta
            yield return www.SendWebRequest();

            //Acción a realizar si la petición se ha ejecutado sin errores
            if (!www.isNetworkError)
            {
                //Se recupera el nombre del cliente
                GameManager.name = www.downloadHandler.text.Replace('"', ' ').Trim();
                //Si la respuesta trae un nombre saluda y activa el panel de training
                if (GameManager.name != "")
                {
                    dniclient.GetComponent<Text>().text = GameManager.name;
                    welcome.GetComponent<Text>().text = String.Format("Hola {0}", GameManager.name);
                    training.SetActive(true);
                }
                else
                {
                    welcome.GetComponent<Text>().text = "Bienvenid@ a Saladillo FIT VR";
                    training.SetActive(false);
                }
            }
        }
    }
}