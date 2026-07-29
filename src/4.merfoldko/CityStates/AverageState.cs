namespace _4.merfoldko.CityStates;

using _4.merfoldko.Tourists;
using _4.merfoldko.Cities;

/// <summary>
/// This class represents the Average state of a city, which is one of the three possible states (Poor, Average, Pristine) that a city can be in based on its condition.
/// </summary>
public class AverageState : ICityState
{
    /// <summary>
    /// This method accepts a tourist and a city as parameters and allows the tourist to visit the city in its average state. 
    /// The tourist will interact with the city based on its current state, which in this case is average.
    /// </summary>
    /// <param name="tourist"> The tourist visiting the city.</param>
    /// <param name="city"> The city being visited.</param>
    public void Accept(ITourist tourist, City city)
    {
        tourist.Visit(this, city);
    }
    /// <summary>
    /// This method changes the state of the city to AverageState if the city's condition is between 34 and 67 (inclusive). If the city's condition falls within this range, it sets the city's state to AverageState.
    /// </summary>
    /// <param name="city"></param>
    public void ChangeState(City city)
    {
        if (city.Condition < 34)
        {
            city.CurrentState = new PoorState();
        }
        else if (city.Condition > 67)
        {
            city.CurrentState = new PristineState();
        }
        
    }
}
