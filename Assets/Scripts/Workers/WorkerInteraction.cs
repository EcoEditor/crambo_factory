using CremboFactory;
using UnityEngine;
using UnityEngine.UI;

namespace Workers
{
    public class WorkerInteraction : MonoBehaviour
    {
        [SerializeField] private Button interactionButton;
        [SerializeField] private int workerIndex;
        
        private void Awake()
        {
            interactionButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            MessagingSystem.WakeupWorker?.Invoke(workerIndex);
        }
    }
}