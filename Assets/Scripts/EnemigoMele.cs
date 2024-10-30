using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemigoMele : Personaje
{
    [SerializeField] private float rangoDeVision = 20f; 
    [SerializeField] private float tiempoAntesDeDuplicarse = 1f; 
    [SerializeField] private GameObject enemigoPrefab; 
    [SerializeField] private float saludMaxima = 100f; 
    [SerializeField] private GameObject cartuchoPrefab;
    private float saludActual;

    private Transform jugador; 
    private NavMeshAgent navMeshAgent; 
    private MeshRenderer meshRenderer;
    private Vector3 destinoAleatorio; 
    private bool persiguiendoJugador = false; 

   new void Start()
   {
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform; 
        navMeshAgent = GetComponent<NavMeshAgent>();
        saludActual = saludMaxima;
        meshRenderer = GetComponent<MeshRenderer>();

        StartCoroutine(MovimientoAleatorio());
   }

    void Update()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        if (distanciaAlJugador < rangoDeVision)
        {
            navMeshAgent.SetDestination(jugador.position);
            persiguiendoJugador = true;
        }
        else if (persiguiendoJugador)
        {
            persiguiendoJugador = false;
            StartCoroutine(MovimientoAleatorio());
        }
    }

    public void RecibirDanio(float cantidadDanio)
    {
        saludActual -= cantidadDanio;

        if (saludActual <= 0)
        {
            Morir();
        }
    }

    public override void Morir()
    {
        meshRenderer.enabled = false;
 
        if (Random.value < 0.9f) 
        {
            Vector3 spawnPosition = transform.position+Vector3.up;
            Instantiate(cartuchoPrefab, spawnPosition, Quaternion.identity); 
        }

        Duplicar();
    }

    private void Duplicar()
    {
        Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }

    private IEnumerator MovimientoAleatorio()
    {
        while (!persiguiendoJugador)
        {
            destinoAleatorio = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)) + transform.position;
            navMeshAgent.SetDestination(destinoAleatorio);

            yield return new WaitForSeconds(5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Proyectil"))
        {
            RecibirDanio(1); 
            Destroy(other.gameObject); 
        }

        if (other.CompareTag("Jugador"))
        {
            other.GetComponent<Jugador>().RecibirDanio(2);
            Destroy(gameObject); 
        }
    }

}
