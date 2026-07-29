namespace _4.merfoldko.CityStates;

using _4.merfoldko.Tourists;
using _4.merfoldko.Cities;

/// <summary>
/// This class represents the Pristine state of a city, which is one of the three possible states (Poor, Average, Pristine) that a city can be in based on its condition.
/// </summary>
public class PristineState : ICityState
{
    /// <summary>
    /// This method accepts a tourist and a city as parameters and allows the tourist to visit the city in its pristine state. 
    ///The tourist will interact with the city based on its current state, which in this case is pristine.
    /// </summary>
    /// <param name="tourist"> The tourist visiting the city.</param>
    /// <param name="city"> The city being visited.</param>
    public void Accept(ITourist tourist, City city)
    {
        tourist.Visit(this, city);
    }
    /// <summary>
    /// This method checks the condition of the city and changes its state to Pristine if the condition is greater than or equal to 68.
    /// </summary>
    /// <param name="city"></param>
    public void ChangeState(City city)
    {
        if (city.Condition < 34)
        {
           city.CurrentState = new PoorState();

        }
        else if (city.Condition < 68)
        {
            city.CurrentState = new AverageState();
        }
    }
}
