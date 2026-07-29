using _4.merfoldko.Cities;
using _4.merfoldko.CityStates;
using _4.merfoldko.Tourists;

namespace _4.merfoldkoTest;

[TestClass]
public class AverageStateTest
{
    [TestMethod]
    public void Accept_WithAverageState_RoutesCorrectly()
    {
        City city = new City(50, 1);
        JapaneseTourists tourist = new JapaneseTourists(100);
        AverageState state = new AverageState();

        state.Accept(tourist, city);

        Assert.AreEqual(100, tourist.Visiting);
    }
}
