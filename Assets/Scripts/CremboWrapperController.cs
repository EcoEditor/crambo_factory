using System;
using UnityEngine;

namespace CremboFactory
{
    public class CremboWrapperController : MonoBehaviour
    {
        [SerializeField] private float wrappingSpeedThreshold = 30f;
        [SerializeField] private float wrappingDuration = 10f;

        private float _startTime;
        private float _endTime;
        
        private void Awake()
        {
            MessagingSystem.CremboWrapStarted += OnCremboWrapStarted;
            MessagingSystem.RotationSpeed += OnRotationSpeed;
        }

        private void OnDestroy()
        {
            MessagingSystem.RotationSpeed -= OnRotationSpeed;
        }

        private void OnCremboWrapStarted(bool didStart)
        {
            if (didStart)
            {
                _startTime = Time.time;
            } else
            {
                _endTime = Time.time;
                if (_endTime - _startTime < wrappingDuration)
                {
                    
                }
            }
        }

        private void OnRotationSpeed(float rotationSpeed)
        {
            if (rotationSpeed > wrappingSpeedThreshold)
            {
                Debug.Log("Rotation is TOO FAST! FAILED");
                MessagingSystem.FailedCremboWrapping?.Invoke();
            }
        }
    }
}
