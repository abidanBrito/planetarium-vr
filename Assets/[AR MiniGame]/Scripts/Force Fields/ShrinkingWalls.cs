using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingWalls : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private float timeInterval = 20.0f;
    [SerializeField] private float jumpStep = 1.0f;
    [SerializeField] private float minimumDistance = 1.0f;

    private void Start()
    {
        StartCoroutine(MoveTowardsCoroutine());
    }

    private IEnumerator MoveTowardsCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);
            
            // Early exit
            if (targetObject == null)
            {
                Debug.LogWarning("Target Object not assigned!");
                yield break;
            }

            // Calculate the direction towards the target
            Vector3 direction = targetObject.transform.position - transform.position;

            // X-axis position
            Vector3 newPosition = new Vector3(Mathf.Min(Mathf.Abs(direction.x), jumpStep), 0, 0);
            if (direction.x < 0)
            {
                transform.position -= newPosition;
            }
            else
            {
                transform.position += newPosition;
            }

            // Boundary
            float boundaryDistance = Vector3.Distance(transform.position, targetObject.transform.position);
            if (minimumDistance <= boundaryDistance)
            {
                Debug.Log("[INFO]: minimum distance reached.");
                yield break;
            }
        }
    }
}