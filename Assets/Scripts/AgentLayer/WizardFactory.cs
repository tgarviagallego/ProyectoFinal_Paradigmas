using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardFactory : MonoBehaviour
{
    private GameObject wizardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        wizardPrefab = Resources.Load<GameObject>("WizardPolyArt/Prefabs/PolyArtWizardStandardMat");
    }

    public GameObject CreateWizard(Vector3 position)
    {
        return Instantiate(wizardPrefab, position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
