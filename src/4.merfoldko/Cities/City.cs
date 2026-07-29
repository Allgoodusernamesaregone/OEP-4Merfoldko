namespace _4.merfoldko.Cities;
using _4.merfoldko.CityStates;
using _4.merfoldko.Tourists;
using _4.merfoldko.Exceptions;


/// <summary>
/// Represents a city with a certain condition and wealth. 
/// The city can be in one of three states: Poor, Average, or Pristine, which are determined by the city's condition. 
///The city can receive money and damage, and it can be renovated if it has enough wealth. The city also accepts tourists, which interact with the city based on its current state.
/// </summary>
public class City
{
    private int _condition;
    private long _wealth;
    private ICityState _currentState;

    /// <summary>
    /// Represents the condition of the city, which is an integer value between 0 and 100.
    /// </summary>
    public int Condition => _condition;
    /// <summary>
    /// Represents the wealth of the city, which is a non-negative long integer. The wealth can be increased by receiving money and decreased by renovating the city.
    /// </summary>
    public long Wealth => _wealth;
    /// <summary>
    /// Represents the current state of the city, which is determined by the city's condition. The state can be Poor, Average, or Pristine, and it affects how tourists interact with the city.
    /// This also affects how different types of tourists will interact with the city, as they may have different preferences and behaviors based on the city's state.
    /// </summary>
    public ICityState CurrentState
    {
        get { return _currentState; } 
        set { _currentState = value; }
    }

    /// <summary>
    /// Initializes a new instance of the City class with the specified condition and wealth values.
    /// </summary>
    /// <remarks>The initial state of the city is set to AverageState and will be updated by the UpdateState
    /// method based on the provided values.</remarks>
    /// <param name="condition">The initial condition of the city. Must be between 0 and 100, inclusive.</param>
    /// <param name="wealth">The initial wealth of the city. Must be zero or greater.</param>
    /// <exception cref="ArgumentException">Thrown if wealth is negative.</exception>
    /// <exception cref="IllegalCityConditionException">Thrown if the condition is outside the valid range of 0 to 100.</exception>"
    public City(int condition, long wealth)
    {
        if (condition < 0 || condition > 100)
        {
            throw new IllegalCityConditionException("Condition must be between 0 and 100");
        }
        if (wealth < 0)
        {
            throw new ArgumentException("Wealth cannot be negative.");
        }
        _currentState = new AverageState(); 
        _condition = condition;
        _wealth = wealth;
        UpdateState();
    }

    /// <summary>
    /// Increases the wealth by the specified amount if the amount is greater than zero.
    /// This method does not perform any action if the provided amount is less than or equal to zero.
    /// </summary>
    /// <param name="amount">The amount of money to add to the wealth. Must be a positive integer.</param>
    public void RecieveMoney(int amount)
    {
        if (amount > 0)
        {
            _wealth += amount;
        }
    }
    /// <summary>
    /// Reduces the current condition by the specified amount of damage, ensuring that the condition does not fall below
    /// zero.
    /// </summary>
    /// <remarks>If the specified damage is greater than the current condition, the condition is set to zero.
    /// This method does not allow the condition to become negative.</remarks>
    /// <param name="damage">The amount of damage to apply. Must be a positive integer; values less than or equal to zero have no effect.</param>
    public void RecieveDamage(int damage)
    {
        if (damage > 0)
        {
            _condition -= damage;
            if (_condition < 0)
            {
                _condition = 0;
            }
        }
    }
    /// <summary>
    /// Determines whether the city can be renovated based on its current wealth. The city can be renovated if its wealth exceeds 20 billion.
    /// </summary>
    /// <returns></returns>
    public bool CanRenovate()
    {
       return _wealth > 20_000_000_000;     
    }

    /// <summary>
    /// Attempts to renovate the city by improving its condition if sufficient wealth is available.
    /// </summary>
    /// <remarks>Renovation is performed only if the current wealth exceeds 20,000,000,000. The city's
    /// condition increases proportionally to the amount of wealth above this threshold, and the excess wealth is
    /// deducted. This method has no effect if renovation is not possible.</remarks>
    public void Renovate()
    {
        if (CanRenovate())
        {
            long excess = _wealth - 20_000_000_000;
            _condition += (int)(excess / 50_000_000);
            _wealth -= excess;
            if (_condition > 100)
            {
                _condition = 100;
            }
        }
    }
    /// <summary>
    /// Acts as the Element of the Visitor design pattern, allowing a tourist to visit the city and interact with it based on the city's current state.
    /// </summary>
    /// <param name="tourist"></param>
    public void Accept(ITourist tourist)
    {
        _currentState.Accept(tourist, this);
    }
    /// <summary>
    /// This method updates the current state of the city based on its condition.
    /// </summary>
    public void UpdateState()
    {
        _currentState.ChangeState(this);
    }
}
