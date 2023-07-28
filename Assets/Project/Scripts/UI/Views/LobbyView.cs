using RedPanda.Project.Constants;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public sealed class LobbyView : View
    {
        [SerializeField] private Button startButton;
        private void Awake()
        {
            startButton.onClick.AddListener(OnStartClicked);
        }

        private void OnStartClicked()
        {
            UIService.Close();
            UIService.Show(ViewConst.PromoView);
        }
    }
}