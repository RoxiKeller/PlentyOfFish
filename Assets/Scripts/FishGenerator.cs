using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class FishGenerator : MonoBehaviour
{
    [SerializeField] private FishPersonality[] personalities;
    [SerializeField] private string[] fishNames;
    [SerializeField] private string[] careers;

    private void Start()
    {
        FishData fish = GenerateFish();

        Debug.Log(
        $"Name: {fish.fishName}\n" +
        $"Personality: {fish.personality.personalityName}\n" +
        $"Career: {fish.career}\n" +
        $"Interests: {string.Join(", ", fish.interests)}"
        );
    }

    public FishData GenerateFish()
    {
        FishPersonality personality =
            personalities[Random.Range(0, personalities.Length)];

        List<string> pool = personality.interests
            .Distinct().ToList();

        List<string> interests = new();

        // Two personality-specific interests
        for (int i = 0; i < 2; i++)
        {
            int index = Random.Range(0, pool.Count);

            interests.Add(pool[index]);
            pool.RemoveAt(index);
        }

        // One wildcard interest
        string[] wildcardPool = personalities
            .Where(p => p != personality)
            .SelectMany(p => p.interests)
            .Distinct()
            .Where(i => !interests.Contains(i))
            .ToArray();

        interests.Add(wildcardPool[
            Random.Range(0, wildcardPool.Length)
        ]);

        return new FishData
        {
            fishName = fishNames[Random.Range(0, fishNames.Length)],
            personality = personality,
            interests = interests.ToArray(),
            career = personality.careers[
                Random.Range(0, personality.careers.Length)
            ]
        };
    }
}