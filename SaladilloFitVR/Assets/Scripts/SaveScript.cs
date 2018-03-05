///////////////////////////////////////////
// Práctica: SaladilloVr
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: SaveScript.cs
///////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour
{
    /// <summary>
    /// Objeto con la dirección ip introducida por el usuario.
    /// </summary>
    public Text ipAddress;

    /// <summary>
    /// Objeto que indica que se ha establecido conexión.
    /// </summary>
    public GameObject connected;

    /// <summary>
    /// Objeto que indica que no se ha establecido conexión.
    /// </summary>
    public GameObject disconnected;

    /// <summary>
    /// Objeto que indica el panel del cliente.
    /// </summary>
    public GameObject clientpanel;

    /// <summary>
    /// Método que se ejecuta cuando se pulsa el botón save.
    /// </summary>
    /// <remarks>
    /// Obtiene la dirección IP introducida por el usuario y la guarda en las preferencias de la aplicación.
    /// </remarks>
    public void Click()
    {
        // Se obtiene la dirección IP introducida por el usuario
        GameManager.ipaddress = ipAddress.GetComponent<Text>().text;
        // Se guarda la dirección IPS
        PlayerPrefs.SetString(GameManager.IP_ADDRESS, GameManager.ipaddress);
        // Se almacena el valor en la configuración de la aplicación
        PlayerPrefs.Save();
        CheckConnectivity();
    }
    
    /// <summary>
    /// Comprueba si existe conexión con la WEB API.
    /// </summary>
    /// <remarks>
    /// Llama a la corrutina CheckConnectivityWEBAPI para comprobar la conexión.
    /// </remarks>
    private void CheckConnectivity()
    {
        StartCoroutine(CheckConnectivityWebApi());
    }

    IEnumerator CheckConnectivityWebApi()
    {
        // Prepara la petición a la webApi
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_CHECK_CONNECTIVITY, GameManager.ipaddress))))
        {
            // hace la peticion a la web api
            yield return www.SendWebRequest();

            // Coprueba el valor devuelto por el método. Si la respuesta es correcta, activa el objeto que indica que se ha establecido conexión, y activa el objeto que indica que está desconectado en caso contrario.
            connected.SetActive(www.responseCode == 200);
            disconnected.SetActive(!connected.activeSelf);
            clientpanel.SetActive(www.responseCode == 200);
        }
    }
}