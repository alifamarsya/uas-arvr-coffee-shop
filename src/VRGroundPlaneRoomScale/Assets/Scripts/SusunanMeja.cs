using UnityEngine;

public class SusunanMeja : MonoBehaviour
{
    public GameObject meja1, meja2, meja3;

    public void SusunanPisah()
    {
        meja1.transform.position = new Vector3(1.22f, 0, 0);
        meja2.transform.position = new Vector3(-1.12f, 0, 2.02f);
        meja3.transform.position = new Vector3(2.88f, 0, 3.94f);
    }

    public void SusunanBesar()
    {
        meja1.transform.position = new Vector3(-0.9f, 0, 2f);
        meja2.transform.position = new Vector3(0, 0, 2f);
        meja3.transform.position = new Vector3(0.9f, 0, 2f);
    }

    public void SusunanJendela()
    {
        meja1.transform.position = new Vector3(2.88f, 0, 1f);
        meja2.transform.position = new Vector3(2.88f, 0, 2f);
        meja3.transform.position = new Vector3(2.88f, 0, 3f);
    }
}
