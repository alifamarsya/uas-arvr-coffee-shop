using UnityEngine;

public class TeleportTombol : MonoBehaviour
{
    public Transform xrOrigin;
    public Transform titikTujuan;

    public void Pindah()
    {
        Vector3 posisiBaru = titikTujuan.position;
        posisiBaru.y = xrOrigin.position.y;
        xrOrigin.position = posisiBaru;
    }
}
