using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    [SerializeField] private Vector3 MousePos;
    public Vector3 MouseDelta => MousePos;
    
    [SerializeField] private bool getMouse;
    public bool getMouseDelta => getMouse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        this.MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.MousePos.z = 0;
        GetMouse();
    }
    void GetMouse()
    {
        if (Input.GetAxis("Fire1") != 1)
        {
            getMouse = false;
        }
        else
        {
            getMouse = true;
        }
    }
}
