public class KoalaCounter : AnimalCounter
{
    protected override void UpdateScore(Animal type)
    {
        if (type is KoalaClass)
        {
            counter++;
            score.text = counter.ToString();
        }
    }
}
