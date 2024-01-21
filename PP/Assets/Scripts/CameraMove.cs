using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    Vector3 posEnd, posSmooth;

    private void FixedUpdate()
    {
        posEnd = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        posSmooth = Vector3.Lerp(transform.position, posEnd, 0.125f);
        transform.position = posSmooth;
    }
}