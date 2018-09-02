using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.SplineFlower.Content;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public SplineWalkerMode WalkerMode { get; set; }

        public enum SplineWalkerTriggerDirection
        {
            Forward,
            Backward,
            ForwardAndBackward
        }
        private SplineWalkerTriggerDirection TriggerDirection { get; set; }

        public enum SplineWalkerInput
        {
            None,
            GamePad,
            Keyboard
        }
        private SplineWalkerInput InputMode { get; set; }

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
        public float GetProgress { get; private set; }
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
            set { _CheckIfWalkingBackwards = value; }
        }
        private bool _TurnWhenWalkingBackwards = false, _CheckIfWalkingBackwards = false;

        private bool _GoingForward = true;
        private bool _LookForward = true;
        private bool _AutoStart = true;
        private bool _ReachedEndOfSpline = false;
        private bool _SplineDirectionChanged = false;
        public int _CurrentTriggerIndex = 0;

        private Keys _ForwardKey, _BackwardKey;
        private Buttons _ForwardButton, _BackwardButton;

        public virtual void CreateSplineWalker(
            BezierSpline spline, 
            SplineWalkerMode mode,
            int duration,
            bool canTriggerEvents = true,
            SplineWalkerTriggerDirection triggerDirection = SplineWalkerTriggerDirection.Forward,
            bool autoStart = true)
        {
            _Spline = spline;
            _AutoStart = autoStart;
            CanTriggerEvents = canTriggerEvents;
            TriggerDirection = triggerDirection;
            Duration = duration;
            WalkerMode = mode;

            SetPosition(spline.GetPoint(0));
            ResetTriggerIndex();

            _Spline.EventTriggered += EventTriggered;

            Initialized = true;
        }

        public void SetInput(Keys forwardKey, Keys backwardKey)
        {
            InputMode = SplineWalkerInput.Keyboard;
            _AutoStart = false;

            _ForwardKey = forwardKey;
            _BackwardKey = backwardKey;
        }
        public void SetInput(Buttons forwardButton, Buttons backwardButton)
        {
            InputMode = SplineWalkerInput.GamePad;
            _AutoStart = false;

            _ForwardButton = forwardButton;
            _BackwardButton = backwardButton;
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
                    if (_GoingForward)
                    {
                        _CurrentTriggerIndex++;
                        if (_CurrentTriggerIndex > _Spline.GetAllTrigger().Count - 1) ResetTriggerIndex();
                    }
                    else
                    {
                        _CurrentTriggerIndex--;
                        if (_CurrentTriggerIndex < 0) ResetTriggerIndex();
                    }
                }
                LastTriggerID = obj.ID;
            }
        }
        protected bool AlreadyTriggered(Trigger trigger)
        {
            if (LastTriggerID == trigger.ID) return true;
            else return false;
        }

        private void ResetTriggerIndex()
        {
            LastTriggerID = new Guid();

            if (!_ReachedEndOfSpline)
            {
                if (_GoingForward &&
                    (TriggerDirection == SplineWalkerTriggerDirection.Forward || TriggerDirection == SplineWalkerTriggerDirection.ForwardAndBackward))
                {
                    _CurrentTriggerIndex = 0;
                }
                else if (TriggerDirection == SplineWalkerTriggerDirection.Backward || TriggerDirection == SplineWalkerTriggerDirection.ForwardAndBackward)
                {
                    _CurrentTriggerIndex = _Spline.GetAllTrigger().Count - 1;
                }
            }
            else if (WalkerMode == SplineWalkerMode.PingPong || InputMode != SplineWalkerInput.None) SetTriggerIndex();
            else if (GetProgress >= 1 && InputMode == SplineWalkerInput.None) _CurrentTriggerIndex = 0;
        }
        private void SetTriggerIndex()
        {
            if (GetProgress >= 1 && TriggerDirection == SplineWalkerTriggerDirection.Forward) _CurrentTriggerIndex = -1;
            if (GetProgress >= 1 && TriggerDirection == SplineWalkerTriggerDirection.Backward) _CurrentTriggerIndex = _Spline.GetAllTrigger().Count - 1;
            if (GetProgress >= 1 && TriggerDirection == SplineWalkerTriggerDirection.ForwardAndBackward) _CurrentTriggerIndex = _Spline.GetAllTrigger().Count - 1;
            if (GetProgress <= 0 && TriggerDirection == SplineWalkerTriggerDirection.Forward) _CurrentTriggerIndex = 0;
            if (GetProgress <= 0 && TriggerDirection == SplineWalkerTriggerDirection.Backward) _CurrentTriggerIndex = -1;
            if (GetProgress <= 0 && TriggerDirection == SplineWalkerTriggerDirection.ForwardAndBackward) _CurrentTriggerIndex = 0;
        }

        public virtual void SetPosition(float progress)
        {
            GetProgress = progress;
        }

        public void SetTriggerPosition(string triggerID, float progress)
        {
            _Spline.GetAllTrigger().Find(x => x.ID.ToString() == triggerID).Progress = progress;
        }

        public virtual Trigger GetTrigger(string triggerID = "SelectedTrigger")
        {
            return _Spline.GetAllTrigger().Find(x => x.ID.ToString() == triggerID);
        }

        public virtual Trigger GetTrigger(int index)
        {
            if (index > -1 && index < _Spline.GetAllTrigger().Count - 1)
            {
                Trigger[] sortedTrigger = _Spline.GetAllTrigger().OrderBy(x => x.Progress).ToArray();

                return sortedTrigger[index];
            }
            return null;
        }

        public List<Trigger> GetTriggers(string name = "")
        {
            if (string.IsNullOrEmpty(name)) return _Spline.GetAllTrigger();
            else return _Spline.GetAllTrigger().FindAll(x => x.Name == name);
        }

        public virtual void Reset(ResetLocation resetLocation = ResetLocation.Start)
        {
            LastTriggerID = new Guid();
            GetProgress = resetLocation == ResetLocation.Start ? 0f : 1f;
            _CurrentTriggerIndex = 0;
        }
        
        public virtual void Update(GameTime gameTime)
        {
            if (GetProgress == 0f || GetProgress == 1f) _ReachedEndOfSpline = true;
            else _ReachedEndOfSpline = false;

            if (_AutoStart)
            {
                if (_GoingForward)
                {
                    GetProgress += (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;
                    if (GetProgress > 1f)
                    {
                        ResetTriggerIndex();

                        if (WalkerMode == SplineWalkerMode.Once)
                        {
                            GetProgress = 1f;
                        }
                        else if (WalkerMode == SplineWalkerMode.Loop)
                        {
                            GetProgress -= 1f;
                        }
                        else
                        {
                            GetProgress = 2f - GetProgress;
                            _GoingForward = false;
                            if (_CheckIfWalkingBackwards) _TurnWhenWalkingBackwards = true;
                        }
                    }
                }
                else
                {
                    GetProgress -= (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;
                    if (GetProgress < 0f)
                    {
                        ResetTriggerIndex();

                        GetProgress = -GetProgress;
                        _GoingForward = true;
                        if (_CheckIfWalkingBackwards) _TurnWhenWalkingBackwards = false;
                    }
                }
            }
            else if (InputMode == SplineWalkerInput.Keyboard)
            {
                if (Keyboard.GetState().IsKeyDown(_ForwardKey)) UpdateForwardMovement(gameTime);
                else if (Keyboard.GetState().IsKeyDown(_BackwardKey)) UpdateBackwardMovement(gameTime);
            }
            else if (InputMode == SplineWalkerInput.GamePad)
            {
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(_ForwardButton)) UpdateForwardMovement(gameTime);
                else if (GamePad.GetState(PlayerIndex.One).IsButtonDown(_BackwardButton)) UpdateBackwardMovement(gameTime);
            }

            if (_LookForward)
            {
                _Direction = _Spline.GetDirection(GetProgress);
                Rotation = (float)Math.Atan2(_Direction.X, -_Direction.Y) - (_TurnWhenWalkingBackwards ? MathHelper.ToRadians(180) : 0);
            }

            SetPosition(_Spline.GetPoint(GetProgress));

            if (CanTriggerEvents &&
                _Spline.GetAllTrigger().Count > 0 &&
                _CurrentTriggerIndex != -1) _Spline.GetAllTrigger()[_CurrentTriggerIndex].CheckIfTriggered(GetProgress);
        }
        private void UpdateForwardMovement(GameTime gameTime)
        {
            if (GetProgress >= 1f)
            {
                if (WalkerMode == SplineWalkerMode.Once) GetProgress = 1f;
                else GetProgress = 0f;

                ResetTriggerIndex();

            }
            else
            {
                GetProgress += (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;

                if (_GoingForward == false) InputDirectionChanged(false);
                _GoingForward = true;
            }
        }
        private void UpdateBackwardMovement(GameTime gameTime)
        {
            if (GetProgress <= 0f)
            {
                if (WalkerMode == SplineWalkerMode.Once) GetProgress = 0f;
                else GetProgress = 1f;

                ResetTriggerIndex();
            }
            else
            {
                GetProgress -= (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;

                if (_GoingForward == true) InputDirectionChanged(true);
                _GoingForward = false;
            }
        }
        private void InputDirectionChanged(bool forwardToBackward)
        {
            if (!_ReachedEndOfSpline)
            {
                if (TriggerDirection == SplineWalkerTriggerDirection.ForwardAndBackward)
                {
                    LastTriggerID = new Guid();

                    if (forwardToBackward)
                    {
                        _CurrentTriggerIndex--;
                        Trigger lastTrigger = _Spline.GetAllTrigger().Last();
                        if (GetProgress > lastTrigger.Progress) _CurrentTriggerIndex = _Spline.GetAllTrigger().Count - 1;
                    }
                    else _CurrentTriggerIndex++;

                    if (_CurrentTriggerIndex > _Spline.GetAllTrigger().Count - 1) _CurrentTriggerIndex = -1;
                }
            }
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
