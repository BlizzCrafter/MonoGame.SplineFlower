using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MonoGame.SplineFlower
{
    public abstract class SplineWalker
    {
        public enum SplineWalkerMode
        {
            Once = 0,
            Loop = 1,
            PingPong = 2
        }
        public SplineWalkerMode Mode { get; set; }

        protected BezierSpline _Spline;

        protected Vector2 Position { get; private set; }
        protected Vector2 Direction
        {
            get
            {
                Vector2 normalized = _Direction;
                normalized.Normalize();
                return normalized;
            }
            private set { _Direction = value; }
        }
        private Vector2 _Direction;
        protected float Rotation { get; private set; }
        protected float Duration { get; set; }
        private Rectangle _Size = new Rectangle(0, 0, 10, 10);
        private void SetPosition(Vector2 position)
        {
            Position = position;
            _Size.X = (int)position.X;
            _Size.Y = (int)position.Y;
        }
        public Vector2 GetPositionOnCurve(float position)
        {
            return _Spline.GetPoint(position);
        }

        public bool Initialized { get; private set; } = false;
        public bool CanTriggerEvents { get; set; } = true;
        public Guid LastTriggerID { get; private set; }

        public float _Progress;
        private bool _GoingForward = true;
        private bool _LookForward = true;
        private bool _AutoStart = true;
        private int _CurrentTriggerIndex = 0;

        public virtual void CreateSplineWalker(
            BezierSpline spline, 
            SplineWalkerMode mode, 
            float duration,
            bool canTriggerEvents = true,
            bool autoStart = true)
        {
            _Spline = spline;
            _AutoStart = autoStart;
            CanTriggerEvents = canTriggerEvents;
            Duration = duration;
            Mode = SplineWalkerMode.Once;

            SetPosition(spline.GetPoint(0));
            _Spline.EventTriggered += EventTriggered;

            Initialized = true;
        }

        public Guid AddTrigger(string name, float progress, int triggerDistance)
        {
            Guid id = _Spline.AddTrigger(name, progress, triggerDistance);
            if (_CurrentTriggerIndex != 0) _CurrentTriggerIndex++;
            return id;
        }
        protected virtual void EventTriggered(Trigger obj)
        {
            if (CanTriggerEvents)
            {
                if (!AlreadyTriggered(obj))
                {
                    _CurrentTriggerIndex++;
                    if (_CurrentTriggerIndex >= _Spline.GetAllTrigger().Count) _CurrentTriggerIndex = 0;
                }
                LastTriggerID = obj.ID;
            }
        }
        protected bool AlreadyTriggered(Trigger trigger)
        {
            if (LastTriggerID == trigger.ID) return true;
            else return false;
        }

        public virtual void SetPosition(float progress)
        {
            _Progress = progress;
        }

        public void SetTriggerPosition(string triggerID, float progress)
        {
            _Spline.GetAllTrigger().Find(x => x.ID.ToString() == triggerID).Progress = progress;
        }

        public virtual Trigger GetTrigger(string triggerID = "SelectedTrigger")
        {
            return _Spline.GetAllTrigger().Find(x => x.ID.ToString() == triggerID);
        }

        public List<Trigger> GetTriggers(string name = "")
        {
            if (string.IsNullOrEmpty(name)) return _Spline.GetAllTrigger();
            else return _Spline.GetAllTrigger().FindAll(x => x.Name == name);
        }

        public void Reset()
        {
            LastTriggerID = new Guid();
            _Progress = 0f;
        }
        
        public virtual void Update(GameTime gameTime)
        {
            if (_AutoStart)
            {
                if (_GoingForward)
                {
                    _Progress += (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;
                    if (_Progress > 1f)
                    {
                        LastTriggerID = new Guid();

                        if (Mode == SplineWalkerMode.Once)
                        {
                            _Progress = 1f;
                        }
                        else if (Mode == SplineWalkerMode.Loop)
                        {
                            _Progress -= 1f;
                        }
                        else
                        {
                            _Progress = 2f - _Progress;
                            _GoingForward = false;
                        }
                    }
                }
                else
                {
                    _Progress -= (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;
                    if (_Progress < 0f)
                    {
                        _Progress = -_Progress;
                        _GoingForward = true;
                    }
                }
            }
            
            if (_LookForward)
            {
                _Direction = _Spline.GetDirection(_Progress);
                Rotation = (float)Math.Atan2(_Direction.X, -_Direction.Y);
            }

            SetPosition(_Spline.GetPoint(_Progress));

            if (CanTriggerEvents && _Spline.GetAllTrigger().Count > 0) _Spline.GetAllTrigger()[_CurrentTriggerIndex].CheckIfTriggered(_Progress);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Setup.Pixel,
                             _Size,
                             null,
                             Color.White,
                             Rotation,
                             new Vector2(0.5f),
                             SpriteEffects.None,
                             0f);
        }
    }
}
