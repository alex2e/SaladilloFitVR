///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Alejandro Santillana
// Curso: 2017/2018
// Fichero: ConfigurationText.cs
///////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

public class CustomPointerTimer : MonoBehaviour
{
    /// <summary>
    ///Objeto compartido por todos los Scripts.
    /// </summary>
    public static CustomPointerTimer CPT;

    /// <summary>
    /// Tiempo por defecto que vamos a tener que esperar para que el contador se rellene.
    /// </summary
    private float timeToWait = 3f;

    /// <summary>
    /// Temporizador.
    /// </summary>
    private float timer = 0f;

    /// <summary>
    /// Componente Image de la imagen de relleno.
    /// </summary>
    private Image image;

    /// <summary>
    /// Cuando está contando.
    /// </summary>
    [HideInInspector] 
    public bool counting = false; //Para que no salga en Unity aunque sea público

    /// <summary>
    /// Indica si ha llegado al final.
    /// </summary>
    [HideInInspector] 
    public bool ended = false;

    /// <summary>
    /// Se invoca antes de que Start.
    /// </summary
    private void Awake()
    {
        //Se comprueba si el objeto está inicializado
        if (CPT == null)
        {
            // Se obtiene el objeto temporizador
            CPT = GetComponent<CustomPointerTimer>();
        }

        // Se obtiene la imagen del reloj
        image = GetComponentInChildren<Image>();
    }


    void Update()
    {
        if (counting)
        {
            //Se incrementa el temporizador la porcion de tiempo que ha tardado en rederizar el ultimo update. De esta manera se tiene un control de tiempo real independientemente de las carsteriticas de máquina
            timer += Time.deltaTime;
            // Se rellena la imagem la camtidad proporcional al temporizador
            image.fillAmount = timer / timeToWait;
        }
        else
        {
            // se reinicia el temporizador
            timer = 0f;
            // Se reinicia el relleno
            image.fillAmount = timer;
        }

        // Se comprueba si ha cumplido el tiempo de espera
        if (timer >= timeToWait)
        {
            // Se indica que el contador ha finalizado
            ended = true;
        }
    }

    /// <summary>
    /// Inicia el temporizador utilizando el tiempo indicado como parametro.
    /// </summary>
    /// <param name="time"></param>
    public void StartCounting(float time)
    {
        counting = true;
        ended = false;
        timeToWait = time;
    }
    
    /// <summary>
    /// Para el temporizador.
    /// </summary>
    public void StopCounting()
    {
        counting = false;
        ended = true;
    }
}