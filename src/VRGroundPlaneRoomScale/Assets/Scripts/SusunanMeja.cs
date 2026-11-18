using UnityEngine;

public class SusunanMeja : MonoBehaviour
{
    public GameObject meja1, meja2, meja3;

    public void SusunanPisah()
    {
        meja1.transform.position = new Vector3(-1.5f, 0, 0.5f);
        meja2.transform.position = new Vector3(1.5f, 0, 0.5f);
        meja3.transform.position = new Vector3(0, 0, -1f);
    }

    public void SusunanBesar()
    {
        meja1.transform.position = new Vector3(-0.9f, 0, 0);
        meja2.transform.position = new Vector3(0, 0, 0);
        meja3.transform.position = new Vector3(0.9f, 0, 0);
    }

    public void SusunanJendela()
    {
        meja1.transform.position = new Vector3(2f, 0, 1f);
        meja2.transform.position = new Vector3(2f, 0, 0);
        meja3.transform.position = new Vector3(2f, 0, -1f);
    }
}
