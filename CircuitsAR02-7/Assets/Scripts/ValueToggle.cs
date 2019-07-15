using UnityEngine;

namespace MagicLeap
{
    /// <summary>
    /// A Toggle Button template that works with VirtualRaycastController
    /// </summary>
    [DisallowMultipleComponent]
    public class ValueToggle : ValueButton
    {
        #region Public Events
        public event System.Action<bool> OnToggle;
        #endregion

        #region Private Variables
        [SerializeField, Tooltip("Initial state of the Toggle")]
        private bool _state = false;
        #endregion

        #region Public Properties
        public bool State
        {
            get { return _state; }
            set
            {
                if (value == _state)
                {
                    return;
                }

                _state = value;
                if (OnToggle != null)
                {
                    OnToggle.Invoke(_state);
                }
            }
        }
        #endregion

        #region Unity Methods
        protected override void OnEnable()
        {
            OnControllerTriggerDown += HandleTriggerDown;

            base.OnEnable();
        }

        protected override void OnDisable()
        {
            //OnControllerTriggerDown -= HandleTriggerDown;

            //base.OnDisable();
        }
        #endregion

        #region Event Handlers
        private void HandleTriggerDown(float triggerValue)
        {
            State = !State;
        }
        #endregion
    }
}
