using DalApi;
using DO;
using System.Collections.Generic;

namespace Dal;
public class AssignmentImplementation : IAssignment
{

    public void Create(Assignment item)
    {

        if (DataSource.Assignments.Any(e => e.Id == item.Id))
            throw new NotImplementedException($"The Call Item with id {item.Id} is already exist");
        int newId =  Config.nextAssignmentId;
        int newIdCall = Config.nextCallId;
        Assignment copyItem = item with { Id = newId, CallId = newIdCall};
        DataSource.Assignments.Add(copyItem);
    }

    public Assignment? Read(int id)
    {
        Assignment foundCall = DataSource.Assignments.FirstOrDefault(e => e.Id == id);
        if (foundCall == null)
            return null;
        return foundCall;
    }

    public List<Assignment> ReadAll()
    {
        return new List<Assignment>(DataSource.Assignments);
    }

    public void Update(Assignment item)
    {

        if (!DataSource.Assignments.Any(e => e.Id == item.Id))
            throw new NotImplementedException($"The Call Item with id {item.Id} isn't exist");
        DataSource.Assignments.RemoveAll(e => e.Id == item.Id);
        DataSource.Assignments.Add(item);

    }

    public void Delete(int id)
    {
        if (!DataSource.Assignments.Any(e => e.Id == id))
            throw new NotImplementedException($"The Call Item with id {id} isn't exist");
        DataSource.Assignments.RemoveAll(e => e.Id == id);
    }

    public void DeleteAll()
    {
        DataSource.Assignments.Clear();
    }

}
