using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARPlaceManager : MonoBehaviour
{
    public GameObject prefabKafeMini;
    public GameObject reticle;
    public ARRaycastManager raycastManager;
    private GameObject kafeYangDiletakkan;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        Vector3 tengahLayar = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        if (raycastManager.Raycast(tengahLayar, hits, TrackableType.PlaneWithinPolygon))
        {
            reticle.SetActive(true);
            reticle.transform.position = hits[0].pose.position;
        }
        else
        {
            reticle.SetActive(false);
        }

        if (Input.touchCount == 0) return;
        Touch sentuhan = Input.GetTouch(0);
        if (sentuhan.phase != TouchPhase.Began) return;
        if (raycastManager.Raycast(sentuhan.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            if (kafeYangDiletakkan == null)
                kafeYangDiletakkan = Instantiate(prefabKafeMini, pose.position, pose.rotation);
            else
                kafeYangDiletakkan.transform.position = pose.position;
        }
    }

    public void PutarKafe()
    {
        if (kafeYangDiletakkan != null)
            kafeYangDiletakkan.transform.Rotate(0, 45f, 0);
    }

    public void PerbesarKafe()
    {
        if (kafeYangDiletakkan != null)
            kafeYangDiletakkan.transform.localScale *= 1.1f;
    }

    public void PerkecilKafe()
    {
        if (kafeYangDiletakkan != null)
            kafeYangDiletakkan.transform.localScale *= 0.9f;
    }

    public void ResetKafe()
    {
        if (kafeYangDiletakkan != null)
        {
            Destroy(kafeYangDiletakkan);
            kafeYangDiletakkan = null;
        }
    }
}
