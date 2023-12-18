using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LookAt : MonoBehaviour
{
public Transform camtransform;
void Update()
{
transform.LookAt(camtransform);
}
}