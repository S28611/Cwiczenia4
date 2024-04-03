using LegacyApp;

namespace LegacyAppTest;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Or_LastName_Is_Null()
    {
        //Arrange
        var service = new UserService();
        
        //Act

        var result = service.AddUser(null, null, "Abrakadabra@gmail.com", new DateTime(1998, 12, 2), 10);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Email_Do_Not_Contains_AT_Or_Dot()
    {
        //Arrange
        var service = new UserService();
        
        //Act
        var result = service.AddUser("Name", "LastName", "testEmail", new DateTime(1998, 12, 2), 10);
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Age_Is_Smaller_Than_21()
    {
        //Arrange
        var service = new UserService(new FakeClientRepository());
        
        //Act
        var result = service.AddUser("Name", "LastName", "testEmail@pjwstk.edu.pl", new DateTime(2015, 12, 2), 10);
        
        //Assert
        Assert.False(result);   
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Very_Important_Client()
    {
        //Arrange
        var service = new UserService(new FakeClientRepository());
        
        //Act
        var result = service.AddUser("Name", "LastName", "testEmail@pjwstk.edu.pl", new DateTime(1998, 12, 2), 2);
        
        //Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Important_Client_And_Credit_Limit_Is_Less_Than_500()
    {
        //Arrange
        var service = new UserService(new FakeClientRepository());
        
        //Act
        var result = service.AddUser("Name", "Kowalski", "testEmail@pjwstk.edu.pl", new DateTime(1998, 12, 2), 1);
        
        //Assert
        Assert.False(result);
    }
}