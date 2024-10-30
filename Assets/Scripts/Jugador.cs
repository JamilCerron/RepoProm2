using UnityEngine;
using System.Collections;

public class Jugador : Personaje
{
    [SerializeField] float rapidezCaminar;
    [SerializeField] float rapidezCorrer;
    [SerializeField] GameObject proyectilPrefab;
    [SerializeField] float velocidadProyectil = 50f;
    [SerializeField] private int recolectables = 0;

    [SerializeField] private int balasActuales = 24; 
    private bool puedeDisparar = true; 


    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        CaminarYCorrer();

        if (Input.GetMouseButtonDown(0) && puedeDisparar && balasActuales > 0)
        {
            StartCoroutine(Disparar());
        }
        else if (Input.GetMouseButtonDown(0) && balasActuales <= 0)
        {
            Debug.Log("Sin balas"); 
        }
    }
    public void AumentarRecolectables(int cantidad)
    {
        recolectables += cantidad;

        if (recolectables >= 5)
        {
            AbrirPuerta();
        }
    }
    private void AbrirPuerta()
    {
        GameObject puerta = GameObject.FindWithTag("Puerta");
        if (puerta != null)
        {
            Debug.Log("Abriendo");
            puerta.GetComponent<Puerta>().Abrir();
        }
    }
    public void AumentarMunicion(int cantidad)
    {
        balasActuales += cantidad;

    }
    void CaminarYCorrer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(horizontal, 0, vertical);
        float velocidad = Input.GetKey(KeyCode.LeftShift) ? rapidezCorrer : rapidezCaminar; // Verifica si se presiona shift izquierdo y asigna un valor a velocidad en consecuencia
        rbd.velocity = direccion * velocidad;
    }

    private IEnumerator Disparar()
    {
        if (balasActuales > 0) 
        {
            GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
            Rigidbody rbProyectil = proyectil.GetComponent<Rigidbody>();

            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition); // Convierte las coordenadas del mouse en un rayo que sale desde la cámara
            Plane plano = new Plane(Vector3.up, Vector3.zero); // Genera un plano para hallar la intersección con este rayo

            float distanciaDeInterseccion;

            if (plano.Raycast(rayo, out distanciaDeInterseccion)) // Verifica si el rayo choca con el plano y si es asi guarda esta distancia del rayo
            {
                Vector3 puntoDeInterseccion = rayo.GetPoint(distanciaDeInterseccion); // Obtiene el punto de intersección (cordenadas)
                Vector3 direccionMouse = (puntoDeInterseccion - transform.position).normalized; // Halla la dirección hacia el mouse

                rbProyectil.velocity = direccionMouse * velocidadProyectil;
                balasActuales--; 

                yield return new WaitForSeconds(0.1f); 
            }
        }
    }

    public void RecogerBalas(int cantidad)
    {
        balasActuales += cantidad;
    }



}
