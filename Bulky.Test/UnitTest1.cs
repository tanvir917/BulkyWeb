namespace Bulky.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        MyMath mm = new MyMath();
        int input1 = 10, input2 = 24;
        int expectedValue = 34;
        //Act
        int actual = mm.Add(10, 24);
        //Assert
        Assert.Equal(expectedValue, actual);
    }
}
