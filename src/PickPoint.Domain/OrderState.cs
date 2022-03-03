namespace PickPoint.Domain;

public enum OrderState
{
    Registered = 1,
    
    AcceptedInStock = 2,
    
    IssuedToTheCourier = 3,
    
    DeliveredToPostOffice = 4,
    
    DeliveredToEecipient = 5,
    
    Canceled = 6
}