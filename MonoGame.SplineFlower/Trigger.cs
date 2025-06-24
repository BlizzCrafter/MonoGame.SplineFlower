using Microsoft.Xna.Framework;

namespace MonoGame.SplineFlower
{
    public class Trigger
    {
        public string Name { get; private set; } = "";
        public Guid ID { get; private set; }
        public float Rotation { get; internal set; }
        public bool Triggered { get; internal set; } = false;
        public object Custom { get; set; }
        public float Progress
        {
            get { return _Progress * (GetMaxProgress != null ? GetMaxProgress() : 1f); }
            set { _Progress = value; }
        }
        public float GetPlainProgress => _Progress;
        private float _Progress = -999f;
        public float TriggerRange
        {
            get { return _TriggerRange / Setup.SplineMarkerResolution; }
            set { _TriggerRange = value; }
        }
        private float _TriggerRange = 3f;

        internal event Action<Trigger> TriggerEvent = delegate { };

        internal Func<float, Vector2> GetDirectionOnSpline { get; set; }
        internal Func<float> GetMaxProgress { get; set; }

        public Trigger() { }
        public Trigger(string name, float progress, float triggerRange, out Guid id)
        {
            Name = name;
            _Progress = progress;
            TriggerRange = triggerRange;
            ID = id = Guid.NewGuid();
        }
        public Trigger(string name, float progress, float triggerRange, string id)
        {
            Name = name;
            _Progress = progress;
            TriggerRange = triggerRange;
            ID = Guid.Parse(id);
        }

        internal void UpdateTriggerRotation()
        {
            Vector2 direction = GetDirectionOnSpline(Progress);
            Rotation = (float)Math.Atan2(direction.X, -direction.Y);
        }

        public bool CheckIfTriggered(float progress)
        {
            float range = MathHelper.Distance(_Progress, progress);
            if (range <= TriggerRange)
            {
                Triggered = true;
                TriggerEvent.Invoke(this);
                return true;
            }
            else return false;
        }
    }
}
