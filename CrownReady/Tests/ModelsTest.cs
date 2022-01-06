using Xunit;
using Models;
using CustomExceptions;

namespace Tests;

public class ModelsTest
{
    [Fact]
    public void StoreFrontShouldCreate()
    {
        StoreFront testStoreFront = new StoreFront();

        Assert.NotNull(testStoreFront);
    }
    [Fact]
    public void StoreFrontShouldSetValidData()
    {
        StoreFront testStoreFront = new StoreFront();
        string name = "Test Name";
        string address = "Test Address";
        string city = "Test City";
        string state = "Test State";

        testStoreFront.Name = name;
        testStoreFront.Address = address;
        testStoreFront.City = city;
        testStoreFront.State = state;

        Assert.Equal(name, testStoreFront.Name);
        Assert.Equal(address, testStoreFront.Address);
        Assert.Equal(city, testStoreFront.City);
        Assert.Equal(state, testStoreFront.State);
    }
    // [Fact]
    [Theory]
    [InlineData("#$^^*@[]")]
    [InlineData("    ")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void StoreFrontShouldNotSetInvalidName(string input)
    {
        StoreFront testStoreFront = new StoreFront();
        // string invalidName = "#$^^*@[]";

        Assert.Throws<InputInvalidException>(() => testStoreFront.Name = input);
    }

    [Fact]
    public void StoreFrontShouldHaveDisplayMethod()
    {
        StoreFront testStoreFront = new StoreFront{
            Name = "Test Name",
            Address = "Test Address",
            City = "Test City",
            State = "Test State"
        };
        string expectedOutput = "Name: Test Name Address: Test Address, Test City, Test State";

        Assert.Equal(expectedOutput, testStoreFront.DisplayStoreFront());

    }
        [Fact]
    public void UserShouldCreate()
    {
        User testUser = new User();

        Assert.NotNull(testUser);
    }

    [Fact]
        public void UserShouldSetData()
    {
        User testUser = new User();
        string name = "Test Name";
        string email = "Test@Email.com";

        testUser.Name = name;
        testUser.Email = email;

        Assert.Equal(name, testUser.Name);
        Assert.Equal(email, testUser.Email);
    }
}