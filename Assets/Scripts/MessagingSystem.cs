using System;
using UnityEngine;

namespace CremboFactory
{
    public static class MessagingSystem
    {
        public static Action<bool> CremboWrapStarted;
        public static Action<float> RotationSpeed;
        public static Action FailedCremboWrapping;
        public static Action SuccessCremboWrapping;
        public static Action<string> SetWorkerAnimationTrigger;
    }
}
