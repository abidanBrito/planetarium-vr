using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class objetoOculto : MonoBehaviour
{
public SteamVR_Action_Boolean buttonA;
public GameObject goOcultar;
void Update()
{
if (buttonA[this.GetComponent<Hand>().handType].stateDown)
{
goOcultar.SetActive(!goOcultar.activeSelf);
}
}
}