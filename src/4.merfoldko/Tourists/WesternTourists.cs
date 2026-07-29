namespace _4.merfoldko.Tourists;

/// <summary>
/// A child class of Tourist that represents Western tourists who visit the city.
/// </summary>
public class WesternTourists : Tourist
{
    protected override double PoorStateMultiplier => 0.0;
    protected override double AverageStateMultiplier => 0.1;
    protected override double PristineStateMultiplier  => 0.3;
    /// <summary>
    /// The constructor for the WesternTourists class initializes the number of people visiting, also the damage they cause, and their budget, which will be determined by the specific type of tourist.
    /// </summary>
    /// <param name="people"></param>
    public WesternTourists(int people) : base(people, 100, 100_000)
    {
    }
}
