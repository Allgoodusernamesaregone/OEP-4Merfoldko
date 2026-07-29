using _4.merfoldko.CityStates;
using _4.merfoldko.Cities;
using _4.merfoldko.Exceptions;
namespace _4.merfoldko.Tourists;
using System;

/// <summary>
/// Represents an abstract base class for tourists, providing functionality to manage the number of visitors, their
/// economic contribution, and the impact of their visits on a city.
/// </summary>
/// <remarks>Derived classes must implement state multipliers to define how the tourist's visit affects the city
/// based on its condition. The class enforces that the number of tourists, their budget, and damage parameters are
/// non-negative upon initialization. Use the Visit methods to apply the effects of tourists to a city in different
/// states. This class is intended to be extended to model specific types of tourists with customized
/// behavior.</remarks>
public abstract class Tourist : ITourist
{
    private int _visiting;
    private int _damageForTourists;
    private int _moneyPerTourist;
    
    protected abstract double PoorStateMultiplier { get; }
    protected abstract double AverageStateMultiplier { get; }
    protected abstract double PristineStateMultiplier  { get; }
    

    /// <summary>
    /// Gets or sets the number of visitors currently present.
    /// </summary>
    /// <remarks>The value must be a non-negative integer. Attempting to set a negative value will result in
    /// an ArgumentException.</remarks>
    public int Visiting
    {
        get => _visiting;
        set
        {
            if (value < 0)
                throw new ArgumentException("Visiting cannot be negative.");
            _visiting = value;
        }
    }
    /// <summary>
    /// Initializes a new instance of the Tourist class with the specified number of people, damage, and budget.
    /// </summary>
    /// <param name="people">The number of people participating in the tour. Must be a non-negative integer.</param>
    /// <param name="damage">The total damage cost incurred by the tourists. Must be a non-negative integer.</param>
    /// <param name="budget">The budget allocated per tourist. Must be a non-negative integer.</param>
    /// <exception cref="ArgumentException">Thrown if any of the parameters 'people', 'damage', or 'budget' are negative.</exception>
    public Tourist(int people, int damage, int budget)
    {
        if (people < 0 || damage < 0 || budget < 0)
        {
            throw new InvalidTouristArgumentException("Invalid tourist argument.");
        }

        _visiting = people;
        _damageForTourists = damage;
        _moneyPerTourist = budget;
    }
    /// <summary>
    /// Visits the specified city and applies effects based on the provided poor state.
    /// </summary>
    /// <param name="state">The poor state that influences the visit operation. Cannot be null.</param>
    /// <param name="city">The city to be visited. Cannot be null.</param>
    public void Visit(PoorState state, City city)
    {
        ExecuteVisit(PoorStateMultiplier, city);
    }
    /// <summary>
    /// Visits the specified city and applies effects based on the provided Average state.
    /// </summary>
    /// <param name="state">The average state that influences the visit operation. Cannot be null.</param>
    /// <param name="city">The city to be visited. Cannot be null.</param>
    public void Visit(AverageState state, City city)
    {
        ExecuteVisit(AverageStateMultiplier, city);
    }
    /// <summary>
    /// Visits the specified city and applies effects based on the provided Pristine state.
    /// </summary>
    /// <param name="state">The pristine state that influences the visit operation. Cannot be null.</param>
    /// <param name="city">The city to be visited. Cannot be null.</param>
    public void Visit(PristineState state, City city)
    {
        ExecuteVisit(PristineStateMultiplier, city);
    }

    /// <summary>
    /// Executes the visit by quantifying the number of tourists, calculating the economic contribution to the city, and applying any
    /// necessary effects based on the city's state.
    /// </summary>
    /// <param name="multiplier"></param>
    /// <param name="city"></param>
    private void ExecuteVisit(double multiplier, City city)
    {
        _visiting += (int)(_visiting * multiplier);
        city.RecieveMoney(_visiting * _moneyPerTourist);
        if (_damageForTourists != 0)
        {
            city.RecieveDamage(_visiting / _damageForTourists);
        } 
    }
}
