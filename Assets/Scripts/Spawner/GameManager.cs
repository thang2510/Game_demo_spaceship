using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] protected Camera Maincamera;
    public Camera maincamera => Maincamera;
 

    private void Awake()
    {
        if (instance != null) return;
        instance = this;    
    }
    private void Reset()
    {
        LoadCamera();
    }

    protected void LoadCamera()
    {
        this.Maincamera = FindFirstObjectByType<Camera>();    
    }

}
