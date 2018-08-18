using Microsoft.Xna.Framework;
using System;

namespace SplineSharp
{
    internal class Trigger
    {
        public Guid ID { get; private set; }
        public float Progress { get; set; } = -999;
        private string _Name = "";

        internal event Action<string> TriggerEvent = delegate { };

        public Trigger(string name, float progress)
        {
            _Name = name;
            Progress = progress;
            ID = Guid.NewGuid();
        }

        public bool CheckIfTriggered(float progress)
        {
            float distance = MathHelper.Distance(Progress, progress);
            if (distance <= 0.010)
            {
                TriggerEvent.Invoke(_Name);
                return true;
            }
            else return false;
        }
    }
}
