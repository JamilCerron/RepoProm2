using UnityEngine;

public class Cartucho : Recolectable
{
    protected override void Recolectar(Jugador jugador)
    {
        jugador.AumentarMunicion(cantidad); 
    }
}

