using Entity;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CurrentModeText : MonoBehaviour
    {
        public GameObject referenceObject;

        private ControllableEntity _entity;
        private Text _currentMode;

        private void OnEnable()
        {
            _currentMode = GetComponent<Text>();
            _entity = referenceObject.GetComponent<ControllableEntity>();
            _entity.OnCurrentModeChanged += UpdateText;
        }

        private void OnDisable()
        {
            _entity.OnCurrentModeChanged -= UpdateText;
        }

        private void UpdateText(string newText)
        {
            _currentMode.text = newText;
        }
    }
}