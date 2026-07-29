namespace _4.merfoldko.CityStates;

using _4.merfoldko.Tourists;
using _4.merfoldko.Cities;

/// <summary>
/// This class represents the Poor state of a city, which is one of the three possible states (Poor, Average, Pristine) that a city can be in based on its condition.
/// </summary>
public class PoorState : ICityState
{
    /// <summary>
    /// This method accepts a tourist and a city as parameters and allows the tourist to visit the city in its poor state. 
    /// The tourist will interact with the city based on its current state, which in this case is poor.
    /// </summary>
    /// <param name="tourist"> The tourist visiting the city.</param>
    /// <param name="city"> The city being visited.</param>
    public void Accept(ITourist tourist, City city)
    {
        tourist.Visit(this, city);
    }
    /// <summary>
    /// This method checks the condition of the city and changes its state to PoorState if the condition is below 34.
    /// </summary>
    /// <param name="city"></param>
    public void ChangeState(City city)
    {
        if (city.Condition > 33)
        {
            city.CurrentState = new AverageState();
        }
        else if (city.Condition > 67)
        {
            city.CurrentState = new PristineState();
        }
    }
}