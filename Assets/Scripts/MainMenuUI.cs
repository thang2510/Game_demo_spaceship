using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuUI : MonoBehaviour
{


    [SerializeField] SceneReference startingLevel;
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;

    void Awake()
    {
        playButton.onClick.AddListener(() => Loader.Load(startingLevel));
        quitButton.onClick.AddListener(() => Application.Quit());
        Time.timeScale = 1f;
    }

}
