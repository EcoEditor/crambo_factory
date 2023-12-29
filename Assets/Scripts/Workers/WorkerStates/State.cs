using UnityEngine;

namespace Workers.WorkerStates
{
    public abstract class State: ScriptableObject
    {
        public abstract void Enter(WorkerController workerController);

        public abstract void Exit();
    }
}