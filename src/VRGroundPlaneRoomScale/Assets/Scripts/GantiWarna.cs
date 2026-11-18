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

    public void ResetWarna()
    {
        dinding.material.color = warnaAwalDinding;
        counter.material.color = warnaAwalCounter;
        meja.material.color = warnaAwalMeja;
    }
}
