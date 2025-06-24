namespace MonoGame.SplineFlower
{
    public class TriggerDummy
    {
        public string Name { get; set; } = "";
        public string ID { get; set; }
        public float Progress { get; set; } = -999;
        public float TriggerRange { get; set; } = 3;

        public TriggerDummy(string name, string id, float progress, float triggerRange)
        {
            Name = name;
            ID = id;
            Progress = progress;
            TriggerRange = triggerRange;
        }
        protected TriggerDummy() { }
    }
}
