using System;
using UnityEngine;
using UnityEngine.Events;

namespace WeatherPlant.BaseMVC
{
    public abstract class BaseViewModel<M, ME> : BaseViewModel<M>
        where ME : UnityEvent<M>
    {
        [SerializeField]
        private ME _onModelUpdate;

        protected override void TriggerModelUpdate(M model)
        {
            base.TriggerModelUpdate(model);

            if (_onModelUpdate != null)
                _onModelUpdate.Invoke(model);
        }
    }

    public abstract class BaseViewModel<M> : MonoBehaviour
    {
        private M _currentModel;

        public event Action<M> OnModelUpdate;

        /// <summary>
        /// Gets or sets the current Weather model
        /// </summary>
        /// <value>The model.</value>
        public M Model
        {
            get { return _currentModel; }
            set
            {
                SetModel(value);
                TriggerModelUpdate(_currentModel);
            }
        }

        protected virtual void SetModel(M model)
        {
            _currentModel = model;
        }

        protected virtual void TriggerModelUpdate(M model)
        {
            if (OnModelUpdate != null)
                OnModelUpdate.Invoke(model);
        }
    }
}
