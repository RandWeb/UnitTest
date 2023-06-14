namespace MoqFramework;

public interface IPersonRepository
{
    int Count { get; set; }
    List<Person> GetAll();
    Task<List<Person>> GetAllAsync();
    List<Person> GetAdultPersons();
    Person Get(int id);
    bool TryGet(int id, out Person person);
}