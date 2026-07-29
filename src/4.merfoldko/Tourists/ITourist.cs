using _4.merfoldko.CityStates;
using _4.merfoldko.Cities;
namespace _4.merfoldko.Tourists;

/// <summary>
/// An interface representing a tourist that can visit cities in different states (Pristine, Average, Poor).
/// </summary>
public interface ITourist
{
    /// <summary>
    /// This is the visitor part of the Visitor design pattern. The tourist will visit a city and perform actions based on the city's pristine state.
    /// </summary>
    /// <param name="pristine"> The visited city's state</param>
    /// <param name="city"> The city being visited</param>
    void Visit(PristineState pristine, City city);
    /// <summary>
    /// This is the visitor part of the Visitor design pattern. The tourist will visit a city and perform actions based on the city's Average state.
    /// </summary>
    /// <param name="average"> The visited city's state</param>
    /// <param name="city"> The city being visited</param>
    void Visit(AverageState average, City city);
    /// <summary>
    /// This is the visitor part of the Visitor design pattern. The tourist will visit a city and perform actions based on the city's Poor state.
    /// </summary>
    /// <param name="poor"> The visited city's state</param>
    /// <param name="city"> The city being visited</param>
    void Visit(PoorState poor, City city);
}
