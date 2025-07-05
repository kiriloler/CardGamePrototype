using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PerksUI : MonoBehaviour
{
    [SerializeField] private PerkUI perkUIPrefab;
    private readonly List<PerkUI> perkUIs = new();
    public void AddPerkUI(Perk perk)
    {
        PerkUI perkUI = Instantiate(perkUIPrefab, transform);
        perkUI.SetUp(perk);
        perkUIs.Add(perkUI);
    }
    public void RemovePerkUI(Perk perk)
    {
        PerkUI perkUI = perkUIs.Where(pui => pui.Perk == perk).FirstOrDefault();
        if(perkUI != null)
        {
            perkUIs.Remove(perkUI);
            Destroy(perkUI.gameObject);
        }
    }
}
