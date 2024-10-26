using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : Personaje
{
    Rigidbody rbd;
    private void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Caminar();
        Correr();
        Saltar();
    }

    protected override void Caminar()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 direccion= new Vector3(Horizontal, 0, Vertical);

        rbd.velocity = direccion * rapidez;

       
      
    }

    protected override void Saltar()
    {

    }

    protected override void Correr()
    {

    }
}
