using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem.LowLevel;

public class Shake : MonoBehaviour
{
    public Camera mainCamera;
    public float magnitude;
    public float duration;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ShakeCamera(duration, magnitude));
        }
    }

    private IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalPosition = mainCamera.transform.localPosition;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            Vector3 offset = Random.insideUnitSphere * magnitude;
            offset.z = 0f;

            mainCamera.transform.localPosition = originalPosition + offset;

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        mainCamera.transform.localPosition = originalPosition;
    }
}