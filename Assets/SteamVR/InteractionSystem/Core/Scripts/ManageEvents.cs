using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ManageEvents : MonoBehaviour
{
    void Awake()
    {
        this.GetComponent<SteamVR_LaserPointer>().PointerClick += PointerClick;
        this.GetComponent<SteamVR_LaserPointer>().PointerIn += PointerInside;
        this.GetComponent<SteamVR_LaserPointer>().PointerOut += PointerOutside;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {   
        UIElement uie = e.target.GetComponent<UIElement>();
        if (uie != null)
        {
            uie.onHandClick.Invoke(this.GetComponent<Hand>());
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        InteractableHoverEvents ihe = e.target.GetComponent<InteractableHoverEvents>();
        if (ihe != null)
        {
            ihe.onHandHoverBegin.Invoke();
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        InteractableHoverEvents ihe = e.target.GetComponent<InteractableHoverEvents>();
        if (ihe != null)
        {
            ihe.onHandHoverEnd.Invoke();
        }
    }
}