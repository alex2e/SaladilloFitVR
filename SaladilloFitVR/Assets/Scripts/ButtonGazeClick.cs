///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: ButtonGazeClick.cs
///////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class ButtonGazeClick : MonoBehaviour
{
    /// <summary>
    /// Indica el tiempo de activación.
    /// </summary>
    public float activationTime = 3f;

    /// <summary>
    /// Indica si está mirandose.
    /// </summary>
    private bool isHover = false;

    /// <summary>
    /// Indica si la acción se ha realizado.
    /// </summary>
    private bool executed = false;


    // Update is called once per frame
    void Update()
    {
        // Si el usuario esta mirando el objeto y el temporizador
        // ha terminado de contrar o si el usuario esta mirando el 
        // objeto y pulsa el botón fire1 del mando y la acción aun
        // no se ha ejecutado, realizaremos la accion correspondiente
        if ((isHover && CustomPointerTimer.CPT.ended && !executed) ||
            (isHover && Input.GetButtonDown("Fire1") && !executed))
        {
            // Se indica que se ha realizado la acción
            executed = true;
            // Desactivaremos el contador de tiempo del cursor, para
            // evitar que se quede bloqueado
            CustomPointerTimer.CPT.StopCounting();
            // Invocar al click del button
            GetComponent<Button>().onClick.Invoke();
        }
    }

    /// <summary>
    /// Metodo que llamaremos desde EventTrigger PointerEmter.
    /// </summary>
    public void StartHover()
    {
        // Indicamos que el objeto esta siendo ,mirado directamente
        isHover = true;
        // Marcamos la acción como no realizada
        executed = false;
        // Iniciamos el contador del puntero, indicadole el tiempo de activación
        CustomPointerTimer.CPT.StartCounting(activationTime);
    }

    /// <summary>
    /// Método que llamaremos desde el eventTrigger pointerexit.
    /// </summary>
    public void EndHover()
    {
        // Indicamos que el objeto ya no esta siendo mirado
        isHover = false;
        //Iniciamos el contador del puntero indicando el tiempo de activación
        CustomPointerTimer.CPT.StopCounting();
    }
}