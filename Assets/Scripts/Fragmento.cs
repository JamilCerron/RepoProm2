using UnityEngine;

public class Fragmento : Recolectable
{
    protected override void Recolectar(Jugador jugador)
    {
        jugador.AumentarRecolectables(cantidad);
       
    }
}

