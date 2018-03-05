///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: ButtonClick.cs
///////////////////////////////////////////

using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    /// <summary>
    /// GameObject que se modifica cuando se pulsa el botón.
    /// </summary>
    public GameObject clickObject;
    // Use this for initialization

    // Use this for initialization
    public void Click()
    {
        //Si el objeto esta activo, lo descativo, si no, lo activo.
        clickObject.SetActive(!clickObject.activeSelf);
    }
}