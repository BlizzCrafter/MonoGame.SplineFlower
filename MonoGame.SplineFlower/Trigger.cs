using Microsoft.Xna.Framework;
using System;

namespace MonoGame.SplineFlower
{
    public class Trigger
    {
        public string Name { get; private set; } = "";
        public Guid ID { get; private set; }
        public float Progress { get; set; } = -999;
        public object Custom { get; set; }
        public float TriggerDistance
        {
            get { return _TriggerDistance / Setup.SplineMarkerResolution; }
            set { _TriggerDistance = value; }
        }
        private float _TriggerDistance = 5f;

        internal event Action<Trigger> TriggerEvent = delegate { };

        public Trigger(string name, float progress, int triggerDistance, out Guid id)
        {
            Name = name;
            Progress = progress;
            TriggerDistance = triggerDistance;
            ID = id = Guid.NewGuid();
        }

        public bool CheckIfTriggered(float progress)
        {
            float distance = MathHelper.Distance(Progress, progress);
            if (distance <= TriggerDistance)
            {
                TriggerEvent.Invoke(this);
                return true;
            }
            else return false;
        }
    }
}
