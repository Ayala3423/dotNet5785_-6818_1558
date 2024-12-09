using DalApi;
using DO;
using System.Collections.Generic;

namespace Dal;
internal class AssignmentImplementation : IAssignment
{

    public void Create(Assignment item)
    {

        if (DataSource.Assignments.Any(e => e.Id == item.Id))
            throw new DalAlreadyExistsException($"The Call Item with id {item.Id} is already exist");
        int newId = Config.nextAssignmentId;
        int newIdCall = Config.nextCallId;
        Assignment copyItem = item with { Id = newId, CallId = newIdCall };
        DataSource.Assignments.Add(copyItem);
    }

    public Assignment? Read(int id)
    {
        return DataSource.Assignments.FirstOrDefault(item => item.Id == id);
    }


    public IEnumerable<Assignment> ReadAll(Func<Assignment, bool>? filter = null) //stage 2
            => filter == null
                ? DataSource.Assignments.Select(item => item)
            : DataSource.Assignments.Where(filter);
    

    public void Update(Assignment item)
    {

        if (!DataSource.Assignments.Any(e => e.Id == item.Id))
            throw new DalDoesNotExistException($"The Call Item with id {item.Id} isn't exist");
        DataSource.Assignments.RemoveAll(e => e.Id == item.Id);
        DataSource.Assignments.Add(item);

    }

    public void Delete(int id)
    {
        if (!DataSource.Assignments.Any(e => e.Id == id))
            throw new DalDeletionImpossible($"The Call Item with id {id} isn't exist");
        DataSource.Assignments.RemoveAll(e => e.Id == id);
    }

    public void DeleteAll()
    {
        DataSource.Assignments.Clear();
    }

    public Assignment? Read(Func<Assignment, bool> filter)
    {

        return DataSource.Assignments.FirstOrDefault(filter);
    }
}
