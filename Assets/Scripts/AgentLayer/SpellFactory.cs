using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFactory : MonoBehaviour
{
    public GameObject fireSpellPrefab; 
    
    public GameObject CreateSpell(string spellType, Vector3 position, Quaternion rotation)
    {
        GameObject spell = null;

        switch (spellType)
        {
            case "Fire":
                spell = Instantiate(fireSpellPrefab, position, rotation);
                break;
        }

        return spell;
    }
}
