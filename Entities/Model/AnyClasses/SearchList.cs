namespace Entities.Model.AnyClasses;

public class SearchList<T>
{
    public int length { get; set; }
    public string type { get; set; }
    public List<T> query_list { get; set; }
}
