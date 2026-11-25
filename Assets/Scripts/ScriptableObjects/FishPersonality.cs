using UnityEngine;

[CreateAssetMenu(menuName = "Fish/Personality")]
public class FishPersonality : ScriptableObject
{
    public string personalityName;

    [TextArea]
    public string description;

    public string[] interests;
    public string[] careers;
}