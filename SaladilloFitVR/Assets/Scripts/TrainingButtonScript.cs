///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: TrainingButtonScript.cs
///////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TrainingButtonScript : MonoBehaviour
{
    /// <summary>
    /// Corresponde al número de entrenamiento asignado.
    /// </summary>
    public int training;

    /// <summary>
    /// Corresponde al panel detail.
    /// </summary>
    public GameObject detail;

    // Corresponde al prefab trainingItem
    public GameObject trainingItem;

    /// <summary>
    /// Al hacer click se ejecutará una corrutina que ejecutuará una pedicion a la api y también guarda dicho entrenamiento
    /// en una constante a nivel de proyecto.
    /// </summary>
    public void Click()
    {
        GetTrainings();
        GameManager.training = training;
    }

    /// <summary>
    /// Método que ejecutará la corrutina, esta enviará una solicitud con el número de entrenamiento y esperará una lista con 3 entrenamientos.
    /// </summary>
    private void GetTrainings()
    {
        StartCoroutine(GetTrainingWebApi());
    }


    IEnumerator GetTrainingWebApi()
    {
        // Se crea la petición a la web api
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_TRAINING, GameManager.ipaddress, training))))
        {
            // Envia la petición a la web api y espera la respuesta
            yield return www.SendWebRequest();

            // Acción a realizar si la peticion se ha ejecutado sin errores
            if (!www.isNetworkError)
            {
                TrainingList trainingListList = JsonUtility.FromJson<TrainingList>(www.downloadHandler.text);
                foreach (Transform child in detail.transform)
                {
                    Destroy(child.gameObject);
                }

                // Asignación del nombre del entrenamiento
                GameObject nameTraining = Instantiate(trainingItem);
                nameTraining.GetComponentInChildren<Text>().text = "Entrenamiento " + training;

                // Se establece su padre que esta en la escena
                nameTraining.transform.SetParent(detail.transform);
                // Se posición en la escena
                nameTraining.GetComponent<RectTransform>().localPosition = new Vector3(1, 0.962f, 4.95f);

                // Se recorre la lista de los ejercicios
                for (int i = 0; i < 3; i++)
                {
                    // Se instancia el objeto
                    GameObject tItem = Instantiate(trainingItem);
                    tItem.GetComponentInChildren<Text>().text = trainingListList.training[i].machine;

                    // Se establece su padre que esta en la escena
                    tItem.transform.SetParent(detail.transform);
                    // Se posición en la escena
                    tItem.GetComponent<RectTransform>().localPosition = new Vector3(1, (-0.2f) * (i + -4f), 4.95f);
                }
            }
        }
    }

    #region Entidades

    public class TrainingList
    {
        public TrainingModel[] training;
    }

    [Serializable]
    public class TrainingModel
    {
        // Identificador del entrenamiento
        public int training;

        // Nombre de la máquina
        public string machine;
    }

    #endregion
}