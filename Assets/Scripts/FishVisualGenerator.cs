using UnityEngine;

public class FishVisualGenerator : MonoBehaviour
{
    [Header("Renderers")]
    [SerializeField] private SpriteRenderer bodyRenderer;
    [SerializeField] private SpriteRenderer accentRenderer;

    [Header("Fish sprites")]
    [SerializeField] private Sprite[] bodySprites;
    [SerializeField] private Sprite[] accentSprites;

    [Header("Possible accent colors")]
    [SerializeField] private Color[] accentColors;

    [ContextMenu("Generate Fish Visual")]

    private void Start()
    {
        GenerateFishVisual();
    }
    public void GenerateFishVisual()
    {
        if (bodySprites.Length == 0 || accentSprites.Length == 0)
        {
            Debug.LogWarning("Missing fish sprites.");
            return;
        }

        int index = Random.Range(0, bodySprites.Length);

        bodyRenderer.sprite = bodySprites[index];
        accentRenderer.sprite = accentSprites[index];

        if (accentColors.Length > 0)
        {
            accentRenderer.color = accentColors[Random.Range(0, accentColors.Length)];
        }
        else
        {
            accentRenderer.color = Random.ColorHSV(
                0f, 1f,      // hue
                0.6f, 1f,    // saturation
                0.7f, 1f     // value
            );
        }
    }
}