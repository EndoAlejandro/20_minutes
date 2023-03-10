using PlayerComponents;
using UnityEngine;
using UnityEngine.UI;
using static PlayerComponents.PlayerXp;

namespace UIComponents
{
    public class UIXp : MonoBehaviour
    {
        private Image _fillImage;
        private Player _player;
        private void Awake()
        {
            _fillImage = GetComponent<Image>();
            _player = FindObjectOfType<Player>();
        }

        private void Start()
        {
            PlayerOnOnXp();
            _player.OnXp += PlayerOnOnXp;
        }
        private void PlayerOnOnXp() => _fillImage.fillAmount = (float)CurrentXpAmount / AmountToNextLevel;
    }
}