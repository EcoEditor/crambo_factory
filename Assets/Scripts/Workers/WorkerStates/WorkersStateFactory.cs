using System;

namespace Workers.WorkerStates
{
    public class WorkersStateFactory
    {
        private readonly SleepingState _sleepingState;
        private readonly WorkingState _workingState;

        public WorkersStateFactory(SleepingState sleepingState, WorkingState workingState)
        {
            _sleepingState = sleepingState;
            _workingState = workingState;
        }

        public State Create(WorkerStates stateType)
        {
            switch (stateType)
            {
                case WorkerStates.Sleeping:
                    return _sleepingState;
                case WorkerStates.Working:
                    return _workingState;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stateType), stateType, null);
            }
        }
    }

    public enum WorkerStates
    {
        Sleeping = 1,
        Working = 2,
    }
}