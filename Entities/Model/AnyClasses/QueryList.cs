namespace Entities.Model.AnyClasses;

public class QueryList<T>
{
    public int length { get; set; }
    public List<T> query_list { get; set; }
}
