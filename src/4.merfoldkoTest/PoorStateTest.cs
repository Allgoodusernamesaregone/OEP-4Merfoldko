using _4.merfoldko.Cities;
using _4.merfoldko.CityStates;
using _4.merfoldko.Tourists;

namespace _4.merfoldkoTest;

[TestClass]
public class PoorStateTest
{
    [TestMethod]
    public void Accept_WithPoorState_RoutesCorrectly()
    {
        City city = new City(10, 1);
        JapaneseTourists tourist = new JapaneseTourists(100);
        PoorState state = new PoorState();

        state.Accept(tourist, city);

        Assert.AreEqual(0, tourist.Visiting);
    }
}
