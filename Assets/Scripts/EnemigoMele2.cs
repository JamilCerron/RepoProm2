using UnityEngine;
using UnityEngine.AI;

public class EnemigoMele2 : Personaje
{
    [SerializeField] private float rangoDeVision = 20f; 
    private Transform jugador; 
    private NavMeshAgent navMeshAgent; 
    new void Start()
    {
        base.Start(); 
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform; 
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        if (distanciaAlJugador < rangoDeVision)
        {
            navMeshAgent.SetDestination(jugador.position);
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
            other.GetComponent<Jugador>().RecibirDanio(1);
            Destroy(gameObject); 
        }
    }

    public override void Morir()
    {
        Destroy(gameObject); 
    }
}
