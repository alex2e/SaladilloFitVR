///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: MoveJostick.cs
///////////////////////////////////////////

using UnityEngine;

public class MoveJoytick : MonoBehaviour
{
    /// <summary>
    /// Máxima velocidad de desplazamiento.
    /// </summary>
    public float maxSpeed = 0.5f;

    /// <summary>
    /// Fuerza de empuje.
    /// </summary
    public float pushForce = 10f;

    /// <summary>
    /// Referencia al Rigibody que queremos mover.
    /// </summary>
    public Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Recuperamos el valor de los ejes horizontal y vertical, son valores normalizados que van de cero a uno.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // Calculamos el vector de movimiento con la direccion a la que mira la camara 
        Vector3 moveDirection = (h * Camera.main.transform.right + v * Camera.main.transform.forward).normalized;
        // comprobamos la magnitud  de desplazamiento y aplicamos el empuje si la velocidad maxima no se ha alcanzado
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(moveDirection * pushForce);
        }
    }
}