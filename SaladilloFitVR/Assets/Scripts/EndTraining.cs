///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: EndTraining.cs
///////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTraining : MonoBehaviour
{
    /// <summary>
    /// Método click del botón que carga la escena Main.
    /// </summary>
    public void Click()
    {
        SceneManager.LoadScene("Main");
    }
}