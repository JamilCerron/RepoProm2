using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemigoMelePrefab; 
    [SerializeField] private float tiempoEntreGeneraciones = 10f; 

    private void Start()
    {
        InvokeRepeating("GenerarEnemigo", 0f, tiempoEntreGeneraciones);
    }

    private void GenerarEnemigo()
    {
        Instantiate(enemigoMelePrefab, transform.position, Quaternion.identity);
    }
}
