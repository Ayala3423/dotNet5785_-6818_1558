namespace Dal;

using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;

internal class CallImplementation : ICall
{
    public void Create(Call item)
    {
        
            if (DataSource.Calls.Any(e => e.Id == item.Id))
                throw new DalAlreadyExistsException($"The Call Item with id {item.Id} is already exist");
            DataSource.Calls.Add(item);
        int newId = Config.nextCallId;
        Call copyItem = item with { Id = newId };
        DataSource.Calls.Add(copyItem);
    }
    public Call? Read(int id) 
    {
        return DataSource.Calls.FirstOrDefault(item => item.Id == id);

    }


    public void Update(Call item)
    {

        if (!DataSource.Calls.Any(e => e.Id == item.Id))
            throw new DalDoesNotExistException($"The Call Item with id {item.Id} isn't exist");
        DataSource.Calls.RemoveAll(e => e.Id == item.Id);
        DataSource.Calls.Add(item);

    }
    public void Delete(int id)
    {
        if (!DataSource.Calls.Any(e => e.Id == id))
            throw new DalDeletionImpossible($"The Call Item with id {id} isn't exist");
        DataSource.Calls.RemoveAll(e => e.Id == id);
    }
    public void DeleteAll()
    {
        DataSource.Calls.Clear();
    }

    public IEnumerable<Call> ReadAll(Func<Call, bool>? filter = null)
    {
        if (filter == null) {
            return DataSource.Calls?.Select(item => item);
        }
        else
        {
            return DataSource.Calls?.Where((Func<Call, bool>)filter);
        }
    }

    public Call? Read(Func<Call, bool> filter)
    {
        return DataSource.Calls.FirstOrDefault(filter);
    }
}
