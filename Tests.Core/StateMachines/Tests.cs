namespace Tests.Core.StateMachines;

[TestFixture]
public class Tests
{
    private readonly TrafficLight _light = new();
    
    [Test]
    public void Test()
    {
        _light.ChangeState(new RedState(_light));
        Assert.That(_light.GetStateLog(), Is.EqualTo("Red"));

        _light.ChangeState(new GreenState(_light));
        Assert.That(_light.GetStateLog(), Is.EqualTo("Green"));
        
        _light.ChangeState(new RedState(_light));
        Assert.That(_light.GetStateLog(), Is.EqualTo("Red"));
    }
}