namespace Dal;

using DalApi;
using DO;
using System.Collections.Generic;
public class CallImplementation : ICall
{
    public void Create(Call item)
    {
        if (item.id)
        {
            if (DataSource.Calls.Any(e => e.id == item.id))
                throw new NotImplementedException($"The Call Item with id {item.id} is already exist");
            DataSource.calls.Add(item);
        }
        else
        {
            Call itemCopy = item.Copy();
            int newId = Config.NextAssignmentId; //לבדוק
            itemCopy.id = newId;
            DataSource.calls.Add(itemCopy);
            return newId;
        }
    }
    public Call? Read(int id) 
    {
       Call foundCall = DataSource.Calls.FirstOrDefault(e => e.id == id);
        if (foundCall == null)
            return null;
        return foundCall;
    }
    public List<Call> ReadAll()
    {
        return new List<Caii>(DataSource.Calls);
    }
    public void Update(Call item)
    {

        if (!DataSource.Calls.Any(e => e.id == item.id))
            throw new NotImplementedException($"The Call Item with id {item.id} isn't exist");
        DataSource.Calls.RemovAll(e => e.id == item.id);
        DataSource.Calls.Add(item);

    }
    public void Delete(int id)
    {
        if (!DataSource.Calls.Any(e => e.id == item.id))
            throw new NotImplementedException($"The Call Item with id {item.id} isn't exist");
        DataSource.Calls.RemovAll(e => e.id ==id);
    }
    public void DeleteAll()
    {
        DataSource.Calls.clear()(e => e.id == id);
    }
}
