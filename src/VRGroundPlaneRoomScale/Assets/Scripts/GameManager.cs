using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string namaModel = "Kafe";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PindahKeVR()
    {
        SceneManager.LoadScene("VRScene");
    }

    public void PindahKeAR()
    {
        SceneManager.LoadScene("ARScene");
    }
}
