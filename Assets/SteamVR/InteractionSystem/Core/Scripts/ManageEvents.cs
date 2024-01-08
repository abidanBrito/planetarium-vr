using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ManageEvents : MonoBehaviour
{
    public SteamVR_Action_Boolean activaLaser;

    void Awake()
    {
        this.GetComponent<SteamVR_LaserPointer>().PointerClick += PointerClick;
        this.GetComponent<SteamVR_LaserPointer>().PointerIn += PointerInside;
        this.GetComponent<SteamVR_LaserPointer>().PointerOut += PointerOutside;
        this.GetComponent<SteamVR_LaserPointer>().enabled = false;

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

    private void Update()
    {
        if (activaLaser[this.GetComponent<Hand>().handType].stateDown)
        {
            this.GetComponent<SteamVR_LaserPointer>().enabled =
            !this.GetComponent<SteamVR_LaserPointer>().enabled;
            GameObject go = this.GetComponent<SteamVR_LaserPointer>().holder;
            if (go != null)
            {
                go.SetActive(this.GetComponent<SteamVR_LaserPointer>().enabled);
            }
        }
    }


}