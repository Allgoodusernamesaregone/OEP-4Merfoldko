using _4.merfoldko.CityStates;
using _4.merfoldko.Cities;
using _4.merfoldko.Exceptions;
using _4.merfoldko.Tourists;

namespace _4.merfoldkoTest;

[TestClass]
public class TouristTest
{
    #region Constructors

    [TestMethod]
    public void Constructor_WithValidParameters_CreatesTourist()
    {
        JapaneseTourists tourist = new JapaneseTourists(100);

        Assert.AreEqual(100, tourist.Visiting);
    }

    [TestMethod]
    public void Constructor_WithNegativePeople_ThrowsInvalidTouristArgumentException()
    {
        Assert.Throws<InvalidTouristArgumentException>(() => new JapaneseTourists(-1));
    }

    [TestMethod]
    public void Constructor_WithZeroPeople_CreatesTourist()
    {
        JapaneseTourists tourist = new JapaneseTourists(0);

        Assert.AreEqual(0, tourist.Visiting);
    }

    #endregion

    #region Visiting Property

    [TestMethod]
    public void Visiting_SetPositiveValue_UpdatesValueSuccessfully()
    {
        JapaneseTourists tourist = new JapaneseTourists(100);

        tourist.Visiting = 150;

        Assert.AreEqual(150, tourist.Visiting);
    }

    [TestMethod]
    public void Visiting_SetZero_UpdatesValueSuccessfully()
    {
        JapaneseTourists tourist = new JapaneseTourists(100);

        tourist.Visiting = 0;

        Assert.AreEqual(0, tourist.Visiting);
    }

    [TestMethod]
    public void Visiting_SetNegativeValue_ThrowsArgumentException()
    {
        JapaneseTourists tourist = new JapaneseTourists(100);

        Assert.Throws<ArgumentException>(() => tourist.Visiting = -10);
    }

    #endregion

    #region Visit (PoorState)

    [TestMethod]
    public void Visit_WithPoorStateAndOtherTourists_AppliesCorrectMultiplier()
    {
        City city = new City(10, 1);
        OtherTourists tourist = new OtherTourists(100);

        PoorState state = new PoorState();
        tourist.Visit(state, city);

        Assert.AreEqual(100, tourist.Visiting);
        
    }
    [TestMethod]
    public void Visit_WithPoorStateAndWesternTourists_AppliesCorrectMultiplier()
    {
        City city = new City(10, 1);
        WesternTourists tourist = new WesternTourists(100);

        PoorState state = new PoorState();
        tourist.Visit(state, city);

        Assert.AreEqual(100, tourist.Visiting);
    }

    [TestMethod]
    public void Visit_WithPoorStateAndJapaneseTourists_AppliesCorrectMultiplier()
    {
        City city = new City(10, 1);
        JapaneseTourists tourist = new JapaneseTourists(100);

        PoorState state = new PoorState();
        tourist.Visit(state, city);

        Assert.AreEqual(0, tourist.Visiting);
    }

    #endregion

    #region Visit (AverageState)

    [TestMethod]
    public void Visit_WithAverageStateAndOtherTourists_AppliesCorrectMultiplier()
    {
        City city = new City(50, 1);
        OtherTourists tourist = new OtherTourists(100);
        AverageState state = new AverageState();
        tourist.Visit(state, city);
        Assert.AreEqual(110, tourist.Visiting);
        
    }



    [TestMethod]
    public void Visit_WithAverageStateAndWesternTourists_AppliesCorrectMultiplier()
    {
        City city = new City(50, 1);
        WesternTourists tourist = new WesternTourists(100);
        AverageState state = new AverageState();
        tourist.Visit(state, city);
        Assert.AreEqual(110, tourist.Visiting);
    }


    [TestMethod]
    public void Visit_WithAverageStateAndJapaneseTourists_AppliesCorrectMultiplier()
    {
        City city = new City(50, 1);
        JapaneseTourists tourist = new JapaneseTourists(100);
        AverageState state = new AverageState();

        tourist.Visit(state, city);

        Assert.AreEqual(100, tourist.Visiting);
    }

    #endregion

    #region Visit (PristineState)

    [TestMethod]
    public void Visit_WithPristineStateAndOtherTourists_AppliesCorrectMultiplier()
    {
        City city = new City(100, 1);
        OtherTourists tourist = new OtherTourists(100);
        PristineState state = new PristineState();
        tourist.Visit(state, city);

        Assert.AreEqual(100, tourist.Visiting);
    }


    [TestMethod]
    public void Visit_WithPristineStateAndWesternTourists_AppliesCorrectMultiplier()
    {
        City city = new City(100, 1);
        WesternTourists tourist = new WesternTourists(100);
        PristineState state = new PristineState();
        tourist.Visit(state, city);

        Assert.AreEqual(130, tourist.Visiting);
        
    }

    [TestMethod]
    public void Visit_WithPristineStateAndJapaneseTourists_AppliesCorrectMultiplier()
    {
        City city = new City(100, 1);
        JapaneseTourists tourist = new JapaneseTourists(100);
        PristineState state = new PristineState();

        tourist.Visit(state, city);

        Assert.AreEqual(120, tourist.Visiting);
        
    }

    #endregion
}

