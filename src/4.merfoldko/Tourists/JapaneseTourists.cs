using _4.merfoldko.CityStates;
using _4.merfoldko.Cities;
namespace _4.merfoldko.Tourists;

/// <summary>
/// A child class of Tourist that represents Japanese tourists who visit the city.
/// </summary>
public class JapaneseTourists : Tourist
{
    protected override double PoorStateMultiplier => -1.0;
    protected override double AverageStateMultiplier => 0.0;
    protected override double PristineStateMultiplier  => 0.2;
    /// <summary>
    /// The constructor for the JapaneseTourists class initializes the number of people visiting, also the damage they cause, and their budget, which will be determined by the specific type of tourist.
    /// </summary>
    /// <param name="people"></param>
    public JapaneseTourists(int people) : base(people, 0, 100_000)
    {
    }
}
