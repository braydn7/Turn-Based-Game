using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Dictionary<GearSlot, Gear> currentGear;
    private CombatantInstance combatant;

    void Awake()
    {
        combatant = GetComponent<CombatantInstance>();
        currentGear = new Dictionary<GearSlot, Gear>();

        foreach(GearSlot slot in System.Enum.GetValues(typeof(GearSlot)))
        {
            currentGear[slot] = null;
        }
    }

    public void Equip(Gear item)
    {
        GearSlot checkedSlot = item.gearSlot;

        if (!CanEquip(item)) {
            return;
        }

        if (currentGear[checkedSlot] != null)
        {
            Debug.Log(checkedSlot + " already has " + currentGear[checkedSlot].name + " equipped. Replacing with " + item.name);
			Unequip(currentGear[checkedSlot]);
            currentGear[checkedSlot] = item;
            combatant.inventory.Remove(item);
        }
        else
        {
            currentGear[checkedSlot] = item;
        }
    }

    public void Unequip(Gear item)
    {
        GearSlot checkedSlot = item.gearSlot;
        if (currentGear[checkedSlot] == null)
        {
            Debug.Log(item.name + " is not equipped... Wait... Then how did you call this? That's a bug. Please let me know haha.");
        }
        else
        {
            currentGear[checkedSlot] = null;
            combatant.inventory.Add(item);
        }
    }

    private bool CanEquip(Gear item)
    {
        foreach (StatRequirement statRequirement in item.statRequirements) {
            BaseStat checkedStat = statRequirement.baseStat;
            int statMin = statRequirement.requirement;
            int characterStat = combatant.stats.Get(checkedStat);

			if (characterStat < statMin)
            {
                Debug.Log(combatant.characterName + " does not have enough " + checkedStat + " to wear " + item.name + ". The minimum " + checkedStat + "required is " + statMin + ". " + combatant.characterName + " only has " + characterStat);
                return false;
            }
        }
        return true;
    }

}
