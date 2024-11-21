using DalApi;
using DO;
using System.Collections.Generic;

namespace Dal;
public class AssignmentImplementation : IAssignment
{
    public void Create(Assignment item)
    {
        if (item.Id)
        {
            if (DataSource.Assignments.Any(e => e.Id == item.Id))
                throw new NotImplementedException($"The Call Item with id {item.id} is already exist");
            DataSource.Assignments.Add(item);
        }
        else
        {
            Assignment itemCopy = item;
            int newId = Config.NextAssignmentId; //לבדוק
            itemCopy.Id = newId;
            DataSource.Assignments.Add(itemCopy);
            //return newId;
        }
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
            throw new NotImplementedException($"The Call Item with id {item.id} isn't exist");
        DataSource.Assignments.RemovAll(e => e.Id == item.Id);
        DataSource.Assignments.Add(item);

    }
    public void Delete(int id)
    {
        if (!DataSource.Assignments.Any(e => e.Id == id))
            throw new NotImplementedException($"The Call Item with id {id} isn't exist");
        DataSource.Assignments.RemovAll(e => e.Id == id);
    }
    public void DeleteAll()
    {
        DataSource.Assignments.Clear();
    }
}
