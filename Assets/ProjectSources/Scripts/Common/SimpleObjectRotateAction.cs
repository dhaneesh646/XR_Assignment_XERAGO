using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class SimpleObjectRotateAction : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] GameObject cube;               

    [Header("Rotation Settings")]
    [SerializeField] float rotationAngle = 90f;
    [SerializeField] float rotationDuration = 1f;

    [Header("Scale Settings")]
    [SerializeField] float scaleMultiplier = 1.2f;   

    [Header("UI Feedback")]
    [SerializeField] Button rotateButton;         
    [SerializeField] Color normalColor = Color.magenta;
    [SerializeField] Color hoverColor = Color.yellow;

    private bool isRotating = false;
    private Vector3 originalScale;

    void Start()
    {
        if (cube != null) originalScale = cube.transform.localScale;

        var colors = rotateButton.colors;
        colors.normalColor = normalColor;
        rotateButton.colors = colors;

        rotateButton.onClick.AddListener(StartCubeAnimation);
    }

    void StartCubeAnimation()
    {
        if (!isRotating && cube != null)
            StartCoroutine(RotateAndScale());
    }

    IEnumerator RotateAndScale()
    {
        isRotating = true;

        Quaternion startRotation = cube.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, rotationAngle, 0);

        float elapsed = 0f;
        while (elapsed < rotationDuration)
        {
            float t = elapsed / rotationDuration;

            cube.transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);

            float pulse = Mathf.Sin(t * Mathf.PI);
            cube.transform.localScale = originalScale * (1 + (scaleMultiplier - 1) * pulse);

            elapsed += Time.deltaTime;
            yield return null;
        }

        cube.transform.rotation = endRotation;
        cube.transform.localScale = originalScale;
        isRotating = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var colors = rotateButton.colors;
        colors.normalColor = hoverColor;
        rotateButton.colors = colors;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var colors = rotateButton.colors;
        colors.normalColor = normalColor;
        rotateButton.colors = colors;
    }
}

