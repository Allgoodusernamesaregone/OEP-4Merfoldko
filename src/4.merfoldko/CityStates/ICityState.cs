namespace _4.merfoldko.CityStates;
using _4.merfoldko.Tourists;
using _4.merfoldko.Cities;

/// <summary>
/// An interface representing the state of a city, which can be one of three possible states: Poor, Average, or Pristine. 
/// </summary>
public interface ICityState
{
    public void Accept(ITourist tourist, City city);
    public void ChangeState(City city);
}
