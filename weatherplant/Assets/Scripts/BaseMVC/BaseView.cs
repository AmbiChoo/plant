using UnityEngine;

namespace WeatherPlant.BaseMVC
{
    public abstract class BaseView<M, VM> : MonoBehaviour
        where VM : BaseViewModel<M>
    {
        [SerializeField]
        private VM _viewModel;

        private void OnEnable()
        {
            if (_viewModel == null)
            {
                Debug.LogWarningFormat("ViewModel [{0}] not found. Searching for one.", typeof(VM));
                _viewModel = GameObject.FindObjectOfType<VM>();

                if (_viewModel == null)
                {
                    Debug.LogErrorFormat("ViewModel [{0}] not found.", typeof(VM));
                    return;
                }
            }

            _viewModel.OnModelUpdate += UpdateView;
        }

        private void OnDisable()
        {
            if (_viewModel == null)
                return;

            _viewModel.OnModelUpdate -= UpdateView;
        }

        protected abstract void UpdateView(M data);
    }
}
