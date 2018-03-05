///////////////////////////////////////////
// Práctica: SaladilloFitVr
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: MovementScript.cs
///////////////////////////////////////////

using UnityEngine;

public class MovementScript : MonoBehaviour
{
    /// <summary>
    /// Velocidad máxima de desplazamiento.
    /// </summary>
    public float maxSpeed = 0.5f;

    /// <summary>
    /// Fuerza de empuje.
    /// </summary>
    public float pushForce = 10f;

    /// <summary>
    /// Indicar si el usuario esta mirando directamente al disco.
    /// </summary>
    [HideInInspector] public bool isHover = false;

    /// <summary>
    /// Referencia al rigidbody que queremos mover.
    /// </summary>
    public Rigidbody rigidbody;

    
    void FixedUpdate()
    {
        if (isHover)
        {
            if (rigidbody.velocity.magnitude < maxSpeed)
            {
                rigidbody.AddForce(
                    (GvrPointerInputModule.Pointer.CurrentRaycastResult.worldPosition - transform.position).normalized *
                    pushForce);
            }
        }
    }

    /// <summary>
    /// Acciones a realizar para el evento de mirar el disco.
    /// </summary>
    public void StartLookingAtDisc()
    {
        isHover = true;
    }

    /// <summary>
    /// Acciones a realizar para el evento de dejar de mirar el disco.
    /// </summary>
    public void StopLookingAtDisc()
    {
        isHover = false;
    }
}