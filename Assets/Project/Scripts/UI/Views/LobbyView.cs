using RedPanda.Project.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI.Views
{
    public sealed class LobbyView : View
    {
        [SerializeField] private Button _startButton;
        private void Awake()
        {
            _startButton.onClick.AddListener(OnStartClicked);
        }

        private void OnStartClicked()
        {
            UIService.Close();
            UIService.Show(ViewConst.PromoView);
        }
    }
}