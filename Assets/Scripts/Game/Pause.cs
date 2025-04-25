using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace GameUI
{
    public class Pause : MonoBehaviour
    {
        private PlayerController _playerController;
        private PostProcessVolume _cameraPostVolume;

        [SerializeField] private KeyCode _pauseButton = KeyCode.Escape;
        [SerializeField] private UI _ui;

        private bool _isPause;

        private void Start()
        {
            _cameraPostVolume = Camera.main.GetComponent<PostProcessVolume>();
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_pauseButton))
            {
                SetPauseEnable(!_isPause);
            }
        }

        public void SetPauseEnable(bool active)
        {
            if (_isPause == active)
                return;

            _cameraPostVolume.isGlobal = active;
            _playerController.enableJump = _playerController.cameraCanMove = !active;


            Time.timeScale = active ? 0f : 1f;
            Cursor.lockState = active ? CursorLockMode.Confined : CursorLockMode.Locked;

            _ui.SetPausePanelActive(active);

            _isPause = active;
        }
    }
}
