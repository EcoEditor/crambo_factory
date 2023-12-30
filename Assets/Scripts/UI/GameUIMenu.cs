using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameUIMenu : MonoBehaviour
    {
        [SerializeField] private int missedCremboThreshold = 20;
        [SerializeField] private GameModel gameModel;
        [SerializeField] private Button exitButton;

        private void Awake()
        {
            exitButton.onClick.AddListener(ExitTutorial);
            gameModel.ChangedMissed += ChangedMissed;
            gameModel.ChangedWrapped += ChangedWrapped;
        }

        private void OnDestroy()
        {
            gameModel.ChangedMissed -= ChangedMissed;
            gameModel.ChangedWrapped -= ChangedWrapped;
        }

        private void ChangedWrapped()
        {
            CheckGameOver();
        }

        private void ChangedMissed()
        {
            CheckGameOver();
        }

        private void CheckGameOver()
        {
            if (gameModel.MissedCrembo >= missedCremboThreshold)
            {
                GameManager.Instance.LoadGameOverScene();
            }
        }

        private void ExitTutorial()
        {
            GameManager.Instance.LoadMainMenuScene();
        }
    }
}