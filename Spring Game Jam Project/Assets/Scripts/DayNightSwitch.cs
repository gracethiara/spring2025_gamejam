using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayNightSwitch : MonoBehaviour
{
    [SerializeField] private float _cooldownTime;
    [SerializeField] private TMP_Text _cooldownText;
    [SerializeField] private Transform _leftMap;
    [SerializeField] private Transform _rightMap;
    [SerializeField] private Image _leftBkgImg;
    [SerializeField] private Image _rightBkgImg;
    [SerializeField] private KeyCode _switchKey;

    private float _currentTime = 0;

    private Vector3 _positiveScale;
    private Vector3 _negativeScale;

    private void Awake()
    {
        _positiveScale = new(1, 1, 1);
        _negativeScale = new(-1, 1, 1);
        _cooldownText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_switchKey) && _currentTime <= 0)
        {
            SwapXScale(_rightMap);
            SwapXScale(_leftMap);
            SwapBkg();
            SetCurrentTime(_cooldownTime);
        }
    }

    private void FixedUpdate()
    {
        if(_currentTime == _cooldownTime)
            _cooldownText.gameObject.SetActive(true);

        if (_currentTime > 0)
            SetCurrentTime(_currentTime - Time.deltaTime);

        else if (_currentTime < 0)
        {
            _cooldownText.gameObject.SetActive(false);
            SetCurrentTime(0);
        }
    }

    private void SetCurrentTime(float p_time)
    {
        _currentTime = p_time;
        _cooldownText.text = ((int)_currentTime).ToString();
    }

    private void SwapBkg()
    {
        Sprite v_rightBkgSprite = _rightBkgImg.sprite;
        Sprite v_leftBkgSprite = _leftBkgImg.sprite;

        _rightBkgImg.sprite = v_leftBkgSprite;
        _leftBkgImg.sprite = v_rightBkgSprite;
    }

    private void SwapXScale(Transform p_targetTransform)
    {
        float v_currentXScale = p_targetTransform.localScale.x;
        Vector3 v_targetScale = v_currentXScale < 0 ? _positiveScale : _negativeScale;

        p_targetTransform.localScale = v_targetScale;
    }
}
