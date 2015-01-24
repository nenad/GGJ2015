using UnityEngine;
using System.Collections;

public class LaptopInteractible : Interactables {

    public override void Use()
    {
        PlanesGame.SetPlanesActive(!PlanesGame.isPlaying);
    }
}
