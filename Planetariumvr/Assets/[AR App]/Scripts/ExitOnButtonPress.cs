using UnityEngine;
using UnityEngine.UI;

public class ExitOnButtonPress : MonoBehaviour
{
	public void Exit(){
		Application.Quit();
		Debug.Log("SALIR PULSADO");

	}
}
