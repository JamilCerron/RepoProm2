using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] protected int vida; 
    protected Rigidbody rbd;

    protected virtual void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }
  
    public void RecibirDanio(int danio)
    {
        vida -= danio;
        if (vida <= 0)
        {
            Morir();
        }
    }

    public virtual void Morir()
    {
        gameObject.SetActive(false);
    }

    

    
}
