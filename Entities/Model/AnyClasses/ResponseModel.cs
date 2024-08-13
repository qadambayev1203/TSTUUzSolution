namespace Entities.Model.AnyClasses;

public class ResponseModel<T>
{
    public int length { get; set; }
    public IEnumerable<T> list { get; set; }
}
