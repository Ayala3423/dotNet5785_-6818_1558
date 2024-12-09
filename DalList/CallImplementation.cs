namespace Dal;

using DalApi;
using DO;
using System.Collections.Generic;
public class CallImplementation : ICall
{
    public void Create(Call item)
    {
        
            if (DataSource.Calls.Any(e => e.Id == item.Id))
                throw new NotImplementedException($"The Call Item with id {item.Id} is already exist");
            DataSource.Calls.Add(item);
        int newId = Config.nextCallId;
        Call copyItem = item with { Id = newId };
        DataSource.Calls.Add(copyItem);
    }
    public Call? Read(int id) 
    {
       Call foundCall = DataSource.Calls.FirstOrDefault(e => e.Id == id);
        if (foundCall == null)
            return null;
        return foundCall;
    }
    public List<Call> ReadAll()
    {
        return new List<Call>(DataSource.Calls);
    }
    public void Update(Call item)
    {

        if (!DataSource.Calls.Any(e => e.Id == item.Id))
            throw new NotImplementedException($"The Call Item with id {item.Id} isn't exist");
        DataSource.Calls.RemoveAll(e => e.Id == item.Id);
        DataSource.Calls.Add(item);

    }
    public void Delete(int id)
    {
        if (!DataSource.Calls.Any(e => e.Id == id))
            throw new NotImplementedException($"The Call Item with id {id} isn't exist");
        DataSource.Calls.RemoveAll(e => e.Id == id);
    }
    public void DeleteAll()
    {
        DataSource.Calls.Clear();
    }
}
