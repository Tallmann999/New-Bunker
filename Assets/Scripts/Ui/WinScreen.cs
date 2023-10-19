using System.Collections;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _winScreen;
    [SerializeField] private CanvasGroup _restartButton;
    [SerializeField] private CanvasGroup _exitButton;
    [SerializeField] private Player _player;

    private Coroutine _activCoroutine = null;
    private WaitForSeconds _sleep = new WaitForSeconds(0.5f);

    private void OnEnable()
    {
        _player.Wined += OnWinActivation;
    }

    private void Start()
    {
        _winScreen.alpha = 0;
        _restartButton.alpha = 0;
        _exitButton.alpha = 0;
    }

    private void OnDisable()
    {
        _player.Wined -= OnWinActivation;
    }

    private void OnWinActivation(bool status)
    {
        if (status)
        {
            if (_activCoroutine != null)
            {
                StopCoroutine(_activCoroutine);
            }

            _activCoroutine = StartCoroutine(SlowScreenActivation());
        }
    }

    private IEnumerator SlowScreenActivation()
    {
        _winScreen.alpha = 1;
        _restartButton.alpha = 1;
        _exitButton.alpha = 1;
        Time.timeScale = 0;
        yield return _sleep;
    }
}
