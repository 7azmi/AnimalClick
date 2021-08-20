using TMPro;
using UnityEngine;

public class PlatypusCounter : AnimalCounter
{
    protected override void UpdateScore(Animal type)
    {
        if (type is PlatypusClass)
        {
            counter++;
            score.text = counter.ToString();
        }
    }
}
