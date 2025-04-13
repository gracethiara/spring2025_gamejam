using UnityEngine;

public class DayNightSwitch : MonoBehaviour
{
    [SerializeField] private Transform _rightMap;
    [SerializeField] private Transform _leftMap;
    [SerializeField] private KeyCode _switchKey;

    private Vector3 _positiveScale;
    private Vector3 _negativeScale;

    private void Awake()
    {
        _positiveScale = new(1, 1, 1);
        _negativeScale = new(-1, 1, 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_switchKey))
        {
            SwapXScale(_rightMap);
            SwapXScale(_leftMap);
        }
    }

    private void SwapXScale(Transform p_targetTransform)
    {
        float v_currentXScale = p_targetTransform.localScale.x;
        Vector3 v_targetScale = v_currentXScale < 0 ? _positiveScale : _negativeScale;

        p_targetTransform.localScale = v_targetScale;
    }
}
