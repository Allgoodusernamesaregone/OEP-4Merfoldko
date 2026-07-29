namespace _4.merfoldko.Tourists;

using _4.merfoldko.Tourists;
using _4.merfoldko.Cities;

/// <summary>
/// A child class of Tourist that represents other tourists who visit the city.
/// </summary>
public class OtherTourists : Tourist
{
    protected override double PoorStateMultiplier => 0.0;
    protected override double AverageStateMultiplier => 0.1;
    protected override double PristineStateMultiplier => 0.0;
    /// <summary>
    /// The constructor for the OtherTourists class initializes the number of people visiting, also the damage they cause, and their budget, which will be determined by the specific type of tourist.
    /// </summary>
    /// <param name="people"></param>
    public OtherTourists(int people) : base(people, 50, 100_000)
    {
    }
}
