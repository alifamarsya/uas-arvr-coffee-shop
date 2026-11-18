using UnityEngine;

public class JalanPC : MonoBehaviour
{
    public float kecepatanJalan = 3f;
    public float kecepatanPutar = 100f;
    private float putarX = 0f;

    void Update()
    {
        float maju = Input.GetAxis("Vertical");
        float samping = Input.GetAxis("Horizontal");
        Vector3 gerak = transform.TransformDirection(new Vector3(samping, 0, maju));
        transform.position += gerak * kecepatanJalan * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X") * kecepatanPutar * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * kecepatanPutar * Time.deltaTime;
        putarX -= mouseY;
        putarX = Mathf.Clamp(putarX, -80f, 80f);
        transform.Rotate(0, mouseX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(putarX, 0, 0);
    }
}
