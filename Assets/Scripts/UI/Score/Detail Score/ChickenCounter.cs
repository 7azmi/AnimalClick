
public class ChickenCounter : AnimalCounter
{
    protected override void UpdateScore(Animal type)
    {
        if (type is ChickenClass)
        {
            counter++;
            score.text = counter.ToString();
        }
    }
}
