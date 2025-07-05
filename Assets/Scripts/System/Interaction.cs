using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : Singleton<Interaction>
{
    public bool PlayerIsDragging { get; set; } = false;
    public bool PlayerCanInteract()
    {
        if (!ActionSystem.Instance.IsPerforming) return true;
        else return false;
    }
    public bool PlayerCanHover()
    {
        if (PlayerIsDragging) return false;
        return true;
    }
}
