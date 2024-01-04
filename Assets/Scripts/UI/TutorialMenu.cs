using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TutorialMenu : MonoBehaviour
    {
        [SerializeField] private Button exitButton;

        private void Awake()
        {
            exitButton.onClick.AddListener(ExitTutorial);
        }

        private void ExitTutorial()
        {
            GameManager.Instance.LoadMainMenuScene();
        }
    }
}