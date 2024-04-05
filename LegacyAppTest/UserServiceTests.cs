using LegacyApp;

namespace LegacyAppTest;

public class UserServiceTests
{
    private FakeClientRepository _fakeClientRepository = new FakeClientRepository();
    
    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Or_LastName_Is_Null()
    {
        //Arrange
        var service = new UserService(_fakeClientRepository);
        
        //Act

        var result = service.AddUser(null, null, "Abrakadabra@gmail.com", new DateTime(1998, 12, 2), 1);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Email_Do_Not_Contains_AT_Or_Dot()
    {
        //Arrange
        var service = new UserService(_fakeClientRepository);
        
        //Act
        var result = service.AddUser("Name", "LastName", "testEmail", new DateTime(1998, 12, 2), 1);
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Age_Is_Smaller_Than_21()
    {
        //Arrange
        var service = new UserService( _fakeClientRepository);
        
        //Act
        var result = service.AddUser("Name", "LastName", "testEmail@pjwstk.edu.pl", new DateTime(2015, 12, 2), 1);
        
        //Assert
        Assert.False(result);   
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Very_Important_Client()
    {
        //Arrange
        var service = new UserService(_fakeClientRepository);
        
        //Act
        var result = service.AddUser("Name", "LastName", "testEmail@pjwstk.edu.pl", new DateTime(1998, 12, 2), 2);
        
        //Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Important_Client_And_Credit_Limit_Is_Less_Than_500()
    {
        //Arrange
        var service = new UserService(_fakeClientRepository);
        
        //Act
        var result = service.AddUser("Name", "Kowalski", "testEmail@pjwstk.edu.pl", new DateTime(1998, 12, 2), 1);
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Important_Client_And_Credit_Limit_Is_Bigger_Than_500()
    {
        //Arrange
        var service = new UserService(_fakeClientRepository);
        
        //Act
        var result = service.AddUser("Name", "Smith", "testEmail@pjwstk.edu.pl", new DateTime(1998, 12, 2), 3);
        
        //Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Normal_Client_And_Credit_Limit_Is_Less_Than_500()
    {
        //Arrange
        var service = new UserService(_fakeClientRepository);

        //Act
        var result = service.AddUser("Name", "Kowalski", "testEmail@pjwstk.edu.pl", new DateTime(1998, 12, 2), 7);

        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Normal_Client_And_Credit_Limit_Is_Bigger_Than_500()
    {
        //Arrange
        var service = new UserService(_fakeClientRepository);

        //Act
        var result = service.AddUser("Name", "Kwiatkowski", "testEmail@pjwstk.edu.pl", new DateTime(1998, 12, 2), 5);

        //Assert
        Assert.True(result);
    }

}