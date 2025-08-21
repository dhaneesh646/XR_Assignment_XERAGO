using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleLabel : MonoBehaviour
{
    public GameObject label;
    [SerializeField] Toggle toggle;

    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        label.SetActive(isOn);
    }
}
