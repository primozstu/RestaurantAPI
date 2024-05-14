namespace Restaurants.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceIdentifier) : Exception($"{resourceType} with id: {resourceIdentifier} doens't exist")
{
    //public NotFoundException(string? message) : base(message)
    //{
    //}

}
