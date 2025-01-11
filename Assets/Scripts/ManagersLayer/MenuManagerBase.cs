using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuManagerBase : MonoBehaviour
{
    [SerializeField] protected GameObject menuCanvas;

    public abstract void HideAllMenus();
    public abstract void EnableMenuControls();
    public virtual void EnableGameplayControls() { }
}
