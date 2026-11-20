using UnityEngine;

public class GantiWarna : MonoBehaviour
{
    public Renderer dinding;
    public Renderer counter;
    public Renderer meja;
    private Renderer bagianTerpilih;
    private Color warnaAwalDinding, warnaAwalCounter, warnaAwalMeja;

    void Start()
    {
        bagianTerpilih = dinding;
        warnaAwalDinding = dinding.material.color;
        warnaAwalCounter = counter.material.color;
        warnaAwalMeja = meja.material.color;
    }

    public void PilihDinding() { bagianTerpilih = dinding; }
    public void PilihCounter() { bagianTerpilih = counter; }
    public void PilihMeja() { bagianTerpilih = meja; }

    public void GantiKeWarna(Color warnaBaru)
    {
        if (bagianTerpilih != null)
            bagianTerpilih.material.color = warnaBaru;
    }
    public void GantiKeKrem() { GantiKeWarna(new Color32(245, 230, 200, 255)); }
    public void GantiKeCoklatMuda() { GantiKeWarna(new Color32(176, 137, 104, 255)); }
    public void GantiKeHijauSage() { GantiKeWarna(new Color32(156, 175, 136, 255)); }
    public void GantiKeCoklatTua() { GantiKeWarna(new Color32(107, 66, 38, 255)); }
    public void GantiKeHitam() { GantiKeWarna(new Color32(0, 0, 0, 255)); }
    public void GantiKePutih() { GantiKeWarna(new Color32(255, 255, 255, 255)); }


    public void ResetWarna()
    {
        dinding.material.color = warnaAwalDinding;
        counter.material.color = warnaAwalCounter;
        meja.material.color = warnaAwalMeja;
    }
}
