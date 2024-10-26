using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] protected float rapidez = 5f;
    [SerializeField] protected float fuerzaDeSalto = 8f;
   
    private void Update()
    {
        Caminar();
        Correr();
        Saltar();
    }

    protected virtual void Caminar()
    {

    }

    protected virtual void Saltar()
    {

    }

    protected virtual void Correr()
    {

    }
}
