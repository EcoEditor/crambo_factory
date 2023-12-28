using UnityEngine;

namespace Workers.WorkerStates
{
    public abstract class State: ScriptableObject
    {
        public abstract void Enter();

        public abstract void Exit();
    }
}