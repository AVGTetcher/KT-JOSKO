using UnityEngine;
using UnityEngine.UI;

public class SphereMover : MonoBehaviour
{
    [SerializeField] private Button _actionButton;
    [SerializeField] private Vector3 _moveOffset = new Vector3(0f, 1f, 0f);

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(Move);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(Move);
    }

    private void Move()
    {
        transform.position += _moveOffset;
    }
}

