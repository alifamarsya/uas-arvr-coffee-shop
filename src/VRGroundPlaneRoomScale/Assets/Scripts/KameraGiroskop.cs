using UnityEngine;

public class KameraGiroskop : MonoBehaviour
{
    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Quaternion gyro = Input.gyro.attitude;
        transform.localRotation = new Quaternion(gyro.x, gyro.y, -gyro.z, -gyro.w);
    }
}
