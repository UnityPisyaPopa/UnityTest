using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    IEnumerator Shake(float duration, float magnitude)
    {
        yield return new WaitForSeconds(magnitude);
    }
}
