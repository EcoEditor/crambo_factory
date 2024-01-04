using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button tutorialButton;

        private void Awake()
        {
            startButton.onClick.AddListener(StartGame);
            tutorialButton.onClick.AddListener(StartTutorial);
        }

        private void StartGame()
        {
            GameManager.Instance.LoadGameScene();
        }

        private void StartTutorial()
        {
            GameManager.Instance.LoadTutorialScene();
        }
    }
}