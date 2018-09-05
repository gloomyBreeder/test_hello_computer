using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "floor")
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnMouseDown()
    {
        StartCoroutine(ChangeScale());
    }

    private IEnumerator ChangeScale()
    {
        // animation for scalling (better to do it in animator but почему бы и нет)

        var scaleCoeff = 1.5f;
        var timeCoeff = 0.5f;
        var originalScale = transform.localScale;
        var destinationScale = originalScale * scaleCoeff;
        var currentTime = 0.0f;

        do
        {
            transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / 0.5f);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= timeCoeff);
        currentTime = 0.0f;
        do
        {
            transform.localScale = Vector3.Lerp(originalScale, originalScale, currentTime / 0.5f);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= timeCoeff);
        
    }
}
