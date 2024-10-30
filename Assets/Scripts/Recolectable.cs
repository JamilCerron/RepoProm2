using UnityEngine;

public class Recolectable : MonoBehaviour
{
    [SerializeField] protected int cantidad;

    protected virtual void Recolectar(Jugador jugador)
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Jugador jugador = other.GetComponent<Jugador>();
            if (jugador != null)
            {
                Recolectar(jugador); 
                Destroy(gameObject); 
            }
        }
    }
}
