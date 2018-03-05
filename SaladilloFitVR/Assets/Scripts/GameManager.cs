
public static class GameManager
{
    /// <summary>
    /// Clave para la dirección IP
    /// </summary>
    public const string IP_ADDRESS = "IP_ADDRESS";

    /// <summary>
    /// Variable para amacenar la IP de la Web API
    /// </summary>
    public static string ipaddress;

    /// <summary>
    /// Clave para el dni del cliente.
    /// </summary>
    public const string DNI_CLIENT = "DNI_CLIENT";

    /// <summary>
    /// Variable que almacena el dni del cliente.
    /// </summary>
    public static string dniclient;

    /// <summary>
    /// Variable que almacena el nombre del cliente.
    /// </summary>
    public static string name;

    /// <summary>
    /// Variable que almacnae el ejercicio elegido
    /// </summary>
    public static int training = 0;

    /// <summary>
    /// Constante con la URL del método de la WEB API para comprobar la conectividad.
    /// </summary> 
    public const string WEB_API_CHECK_CONNECTIVITY = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/CheckConnectivity";

    /// <summary>
    /// Constante con la URL del método de la WEB API para obtener clientes.
    /// </summary>
    public const string WEB_API_GET_CLIENT = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetClientName?dni={1}";
    
    
    /// <summary>
    /// Constante para obtener los ejercicios.
    /// </summary>
    public const string WEB_API_GET_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetTraining?training={1}";

    /// <summary>
    /// Constante efectuar el log a la api.
    /// </summary>
    public const string LOG_API_GET_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/LogTraining";
}