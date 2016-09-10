namespace HomeRoom_Mobile.Models
{
    /// <summary>
    /// Base object iterface.
    /// All objects my implement the Id and web id. 
    /// </summary>
    public interface IBaseObject
    {
        long Id { get; set; }

        long WebId { get; set; }
    }

}
