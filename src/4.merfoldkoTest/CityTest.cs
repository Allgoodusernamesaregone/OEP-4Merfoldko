using _4.merfoldko.Cities;
using _4.merfoldko.Exceptions;
using _4.merfoldko.Tourists;
using _4.merfoldko.CityStates;
namespace _4.merfoldkoTest;

[TestClass]
public sealed class CityTest
{
    #region Constructors

    [TestMethod]
    public void Constructor_WithValidParameters_CreatesCity()
    {
        City city = new City(80, 50);

        Assert.AreEqual(50, city.Wealth);
        Assert.AreEqual(80, city.Condition);
    }

    [TestMethod]
    public void Constructor_WithInvalidWealth_ThrowsException()
    {

        Assert.Throws<ArgumentException>(() => new City(50, -1));
        
    }
    
    [TestMethod]
    public void Constructor_WithTooLowCondition_ThrowsException()
    {
        Assert.Throws<IllegalCityConditionException>(() => new City(-1, 50));
    }

    [TestMethod]
    public void Constructor_WithTooHighCondition_ThrowsException()
    {
        Assert.Throws<IllegalCityConditionException>(() => new City(105, 50));
        
    }

    #endregion

    #region RecieveMoney

    [TestMethod]
    public void RecieveMoney_WithPositiveAmount_IncreasesWealth()
    {
        City city = new City(50, 50);
        city.RecieveMoney(100);

        Assert.AreEqual(150, city.Wealth);
    }

    [TestMethod]
    public void RecieveMoney_WithZeroAmount_DoesNotChangeWealth()
    {
        City city = new City(50, 50);
        city.RecieveMoney(0);

        Assert.AreEqual(50, city.Wealth);
    }

    [TestMethod]
    public void RecieveMoney_WithNegativeAmount_DoesNotChangeWealth()
    {
        City city = new City(50, 50);
        city.RecieveMoney(-100);

        Assert.AreEqual(50, city.Wealth);
    }

    #endregion

    #region RecieveDamage

    [TestMethod]
    public void RecieveDamage_WithPositiveDamage_DecreasesCondition()
    {
        City city = new City(50, 50);
        city.RecieveDamage(20);

        Assert.AreEqual(30, city.Condition);
    }

    [TestMethod]
    public void RecieveDamage_WithDamageExceedingCondition_SetsConditionToZero()
    {
        City city = new City(50, 50);
        city.RecieveDamage(60);

        Assert.AreEqual(0, city.Condition);
    }
    [TestMethod]
    public void RecieveDamage_WithZeroDamage_DoesNotChangeCondition()
    {
        City city = new City(50, 50);
        city.RecieveDamage(0);

        Assert.AreEqual(50, city.Condition);
    }
    [TestMethod]
    public void RecieveDamage_WithNegativeDamage_DoesNotChangeCondition()
    {
        City city = new City(50, 50);
        city.RecieveDamage(-20);

        Assert.AreEqual(50, city.Condition);
    }



    #endregion

    #region CanRenovate

    [TestMethod]
    public void CanRenovate_WithWealthAboveThreshold_ReturnsTrue()
    {
        City city = new City(50, 25_000_000_000);

        Assert.IsTrue(city.CanRenovate());
    }

    [TestMethod]
    public void CanRenovate_WithWealthAtThreshold_ReturnsFalse()
    {
        City city = new City(50, 20_000_000_000);

        Assert.IsFalse(city.CanRenovate());
    }

    [TestMethod]
    public void CanRenovate_WithWealthBelowThreshold_ReturnsFalse()
    {
        City city = new City(50, 10_000_000_000);

        Assert.IsFalse(city.CanRenovate());
    }
    [TestMethod]
    public void CanRenovate_WithNegativeWealth_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new City(50, -1));
    }
    [TestMethod]
    public void CanRenovate_WithZeroWealth_ReturnsFalse()
    {
        City city = new City(50, 0);
        Assert.IsFalse(city.CanRenovate());
    }



    #endregion

    #region Renovate

    [TestMethod]
    public void Renovate_WithSufficientWealth_ImprovesCondition()
    {
        City city = new City(50, 20_500_000_000);
        city.Renovate();

        Assert.AreEqual(60, city.Condition);
    }
    [TestMethod]
    public void Renovate_WithInsufficientWealth_DoesNotChangeCondition()
    {
        City city = new City(50, 19_000_000_000);
        city.Renovate();

        Assert.AreEqual(50, city.Condition);
    }
    [TestMethod]
    public void Renovate_WithoutCanRenovate_DoesNotChangeCondition()
    {
        City city = new City(50, 19_000_000_000);
        city.Renovate();

        Assert.AreEqual(50, city.Condition);
    }

    [TestMethod]
    public void Renovate_WithSufficientWealth_ReducesWealth()
    {
        City city = new City(50, 20_500_000_000);
        city.Renovate();
        Assert.AreEqual(20_000_000_000, city.Wealth);
    }
    
    [TestMethod]
    public void Renovate_WithInsuficientWealth_DoesNotChangeWealth()
    {
        City city = new City(50, 19_000_000_000);
        city.Renovate();
        Assert.AreEqual(19_000_000_000, city.Wealth);
    }
    [TestMethod]
    public void Renovate_WithoutCanRenovate_DoesNotChangeWealth()
    {
        City city = new City(50, 19_000_000_000);
        city.Renovate();
        Assert.AreEqual(19_000_000_000, city.Wealth);
    }

    #endregion

    #region Accept

    [TestMethod]
    public void Accept_WithVisitor_ProcessesVisitor()
    {
        City city = new City(50, 50);
        JapaneseTourists tourists = new JapaneseTourists(1);
        city.Accept(tourists);
        
    }



    #endregion

    #region UpdateState

    [TestMethod]
    public void UpdateState_WithCondition33_SetsStateToPoor()
    {
        City city = new City(33, 50);
        city.UpdateState();
        
        Assert.IsInstanceOfType(city.CurrentState, typeof(PoorState));
    }
    [TestMethod]
    public void UpdateState_WithCondition0_SetsStateToPoor()
    {
        City city = new City(0, 50);
        city.UpdateState();
        Assert.IsInstanceOfType(city.CurrentState, typeof(PoorState));
    }
    [TestMethod]
    public void UpdateState_WithCondition35_SetsStateToAverage()
    {
        City city = new City(35, 50);
        city.UpdateState();
        Assert.IsInstanceOfType(city.CurrentState, typeof(AverageState));
    }
    [TestMethod]
    public void UpdateState_WithCondition67_SetsStateToAverage()
    {
        City city = new City(67, 50);
        city.UpdateState();
        Assert.IsInstanceOfType(city.CurrentState, typeof(AverageState));
    }
    [TestMethod]
    public void UpdateState_WithCondition68_SetsStateToPristine()
    {
        City city = new City(68, 50);
        city.UpdateState();
        Assert.IsInstanceOfType(city.CurrentState, typeof(PristineState));
    }
    [TestMethod]
    public void UpdateState_WithCondition100_SetsStateToPristine()
    {
        City city = new City(100, 50);
        city.UpdateState();
        Assert.IsInstanceOfType(city.CurrentState, typeof(PristineState));
    }

    #endregion

}
