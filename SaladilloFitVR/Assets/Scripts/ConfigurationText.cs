///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: ConfigurationText.cs
///////////////////////////////////////////

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConfigurationText : MonoBehaviour
{
    /// <summary>
    /// Objeto que indica que se ha establecido conexión.
    /// </summary>
    public GameObject connected;

    /// <summary>
    /// Objeto que indica que se ha no establecido conexión.
    /// </summary>
    public GameObject disconnected;

    /// <summary>
    /// Objeto panel del cliente.
    /// </summary>
    public GameObject panelClient;

    void Start()
    {
        // Se recupera el valor de direccion ip almacenado en la configuración de la aplicación
        GameManager.ipaddress = PlayerPrefs.GetString(GameManager.IP_ADDRESS);
        // Muestra la dirección ip
        GetComponent<Text>().text = GameManager.ipaddress;

        CheckConnectivity();
    }

    /// <summary>
    /// Comprueba si existe conexión con la web API.
    /// </summary>
    /// <remarks>
    /// Llama a la corrutina CheckConnectivityWebApi para comprobar la conexión.
    /// </remarks>
    private void CheckConnectivity()
    {
        StartCoroutine(CheckConnectivityWebApi());
    }


    IEnumerator CheckConnectivityWebApi()
    {
        // Prepara la peticion
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_CHECK_CONNECTIVITY, GameManager.ipaddress))))
        {
            // Hace la peticion a la web api
            yield return www.SendWebRequest();

            // Comprueba el valor devuelto por el metodo , si la respuesta es correcta activa la bola connected sino activa la esfera disconned
            // ademas activa o desactiva el panel del cliente si la conexión es favorable
            connected.SetActive(www.responseCode == 200);
            panelClient.SetActive(www.responseCode == 200);
            disconnected.SetActive(!connected.activeSelf);
        }
    }
}