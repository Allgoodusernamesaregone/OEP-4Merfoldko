using _4.merfoldko.CityStates;
using _4.merfoldko.Cities;
using _4.merfoldko.Tourists;

namespace _4.merfoldkoTest;

[TestClass]
public class PristineStateTest
{
    [TestMethod]
    public void Accept_WithPristineState_RoutesCorrectly()
    {
        City city = new City(100, 1);
        JapaneseTourists tourist = new JapaneseTourists(100);
        PristineState state = new PristineState();

        state.Accept(tourist, city);

        Assert.AreEqual(120, tourist.Visiting);
    }
}
