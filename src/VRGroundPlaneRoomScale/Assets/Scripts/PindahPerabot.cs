using UnityEngine;
using UnityEngine.EventSystems;

public class PindahPerabot : MonoBehaviour
{
    public GameObject perabotTerpilih;
    public LayerMask lapisanLantai;

    void Update()
    {
        if (perabotTerpilih == null) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (Input.touchCount == 0 && !Input.GetMouseButtonDown(0)) return;

        Vector3 posisiLayar = Input.touchCount > 0
            ? (Vector3)Input.GetTouch(0).position
            : Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(posisiLayar);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, lapisanLantai))
        {
            Vector3 posisiBaru = hit.point;
            posisiBaru.y = perabotTerpilih.transform.position.y;
            perabotTerpilih.transform.position = posisiBaru;
        }
    }

    public void PilihPerabot(GameObject perabot)
    {
        perabotTerpilih = perabot;
    }
}
