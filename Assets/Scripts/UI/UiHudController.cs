using TMPro;
using UnityEngine;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UiHudController : MonoBehaviour
    {
        [SerializeField] private GameModel gameModel; 
        [SerializeField] private TMP_Text wrappedCount;
        [SerializeField] private TMP_Text missedCount;
        public int max_missed;

        private void Awake()
        {
            gameModel.ChangedMissed += ChangedMissed;
            gameModel.ChangedWrapped += ChangedWrapped;
            
            gameModel.ResetCount();
            
            ChangedMissed();
            ChangedWrapped();
        }

        private void OnDestroy()
        {
            gameModel.ChangedMissed -= ChangedMissed;
            gameModel.ChangedWrapped -= ChangedWrapped;
        }

        private void ChangedWrapped()
        {
            wrappedCount.text = gameModel.WrappedCrembos.ToString();
        }

        private void ChangedMissed()
        {
            missedCount.text = gameModel.MissedCrembo.ToString();
            if (gameModel.MissedCrembo > max_missed)
            {
                ExitGame();
            }
        }
        private void ExitGame()
        {
            GameManager.Instance.LoadGameOverScene();
        }
    }
}