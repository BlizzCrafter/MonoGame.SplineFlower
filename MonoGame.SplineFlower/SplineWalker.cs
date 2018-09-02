using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.SplineFlower.Content;
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

        public enum ResetLocation
        {
            Start,
            End
        }

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
        public float Progress { get; private set; }
        protected float Rotation { get; private set; }
        public int Duration { get; set; }
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
        public Guid LastTriggerID { get; private set; }
        public bool CanTriggerEvents { get; set; } = true;
        public bool TurnWhenWalkingBackwards
        {
            get { return _TurnWhenWalkingBackwards; }
            set
            {
                _CheckIfWalkingBackwards = value;
            }
        }
        private bool _TurnWhenWalkingBackwards = false, _CheckIfWalkingBackwards = false;

        private bool _GoingForward = true;
        private bool _LookForward = true;
        private bool _AutoStart = true;
        private int _CurrentTriggerIndex = 0;

        public virtual void CreateSplineWalker(
            BezierSpline spline, 
            SplineWalkerMode mode, 
            int duration,
            bool canTriggerEvents = true,
            bool autoStart = true)
        {
            _Spline = spline;
            _AutoStart = autoStart;
            CanTriggerEvents = canTriggerEvents;
            Duration = duration;
            Mode = mode;

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
            Progress = progress;
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

        public virtual void Reset(ResetLocation resetLocation = ResetLocation.Start)
        {
            LastTriggerID = new Guid();
            Progress = resetLocation == ResetLocation.Start ? 0f : 1f;
            _CurrentTriggerIndex = 0;
        }
        
        public virtual void Update(GameTime gameTime)
        {
            if (_AutoStart)
            {
                if (_GoingForward)
                {
                    Progress += (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;
                    if (Progress > 1f)
                    {
                        LastTriggerID = new Guid();

                        if (Mode == SplineWalkerMode.Once)
                        {
                            Progress = 1f;
                        }
                        else if (Mode == SplineWalkerMode.Loop)
                        {
                            Progress -= 1f;
                        }
                        else
                        {
                            Progress = 2f - Progress;
                            _GoingForward = false;
                            if (_CheckIfWalkingBackwards) _TurnWhenWalkingBackwards = true;
                        }
                    }
                }
                else
                {
                    Progress -= (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;
                    if (Progress < 0f)
                    {
                        Progress = -Progress;
                        _GoingForward = true;
                        if (_CheckIfWalkingBackwards) _TurnWhenWalkingBackwards = false;
                    }
                }
            }
            
            if (_LookForward)
            {
                _Direction = _Spline.GetDirection(Progress);
                Rotation = (float)Math.Atan2(_Direction.X, -_Direction.Y) - (_TurnWhenWalkingBackwards ? MathHelper.ToRadians(180) : 0);
            }

            SetPosition(_Spline.GetPoint(Progress));

            if (CanTriggerEvents && _Spline.GetAllTrigger().Count > 0) _Spline.GetAllTrigger()[_CurrentTriggerIndex].CheckIfTriggered(Progress);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Setup.ShowBezierSpline && Setup.ShowSplineWalker)
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
}
