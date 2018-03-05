///////////////////////////////////////////
// Práctica: SaladilloVr
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: StartTrainingScript.cs
///////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class StartTrainingScript : MonoBehaviour
{
    /// <summary>
    /// Método click del botón.
    /// <remarks>
    /// Al efectuar click llama a una corrutina que efectua un metodo post a la base de datos.
    /// </remarks>
    /// </summary>
    public void Click()
    {
        
        // Llama al método que guarda la información del cliente
        if (GameManager.training != 0)
        {
            LogClient();
        }
    }

    /// <summary>
    /// Guarda la información del cliente.
    /// </summary>
    /// <remarks>
    /// Llama a una corrutina que conecta con la WebAPI para guardar la información.
    /// </remarks>
    private void LogClient()
    {
        StartCoroutine(LogClientWebAPI());
    }

    IEnumerator LogClientWebAPI()
    {
        //Construimos la información que se envía a la Web API
        WWWForm form = new WWWForm();
        form.AddField("dni", GameManager.dniclient);
        form.AddField("training", GameManager.training);

        // Crea la petición a la Web API
        using (UnityWebRequest www = UnityWebRequest.Post(
            Uri.EscapeUriString(string.Format(GameManager.LOG_API_GET_TRAINING, GameManager.ipaddress)), form))
        {
            // Envía la petición a la Web API y espera la respuesta
            yield return www.SendWebRequest();

            // Acción a realizar si la petición se ha ejecutado sin error
            if (!www.isNetworkError)
            {
                // Carga la escena Machines
                SceneManager.LoadScene("Machines");
            }
        }
    }
}