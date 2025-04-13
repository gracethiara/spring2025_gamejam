using UnityEngine;
using UnityEngine.UI;

public class LayoutRefresher : MonoBehaviour
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
    }

    private void Update()
    {
        //LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
    }
}
