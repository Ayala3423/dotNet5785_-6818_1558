using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;

namespace Dal;
internal class VolunteerImplementation : IVolunteer
{
    public void Create(Volunteer item)
    {
        if (DataSource.Volunteers!.Any(e => e.Id == item.Id))
            throw new DalAlreadyExistsException($"The Call Item with id {item.Id} is already exist");
        DataSource.Volunteers.Add(item);
    }
    public Volunteer? Read(int id)
    {
        return DataSource.Volunteers!.FirstOrDefault(item => item.Id == id);
    }
    public IEnumerable<Volunteer> ReadAll(Func<Volunteer, bool>? filter = null) //stage 2
        => filter == null
            ? DataSource.Volunteers!.Select(item => item)
            : DataSource.Volunteers!.Where(filter);

    public void Update(Volunteer item)
    {

        if (!DataSource.Volunteers!.Any(e => e.Id == item.Id))
            throw new DalDoesNotExistException($"The Call Item with id {item.Id} isn't exist");
        DataSource.Volunteers!.RemoveAll(e => e.Id == item.Id);
        DataSource.Volunteers.Add(item);

    }
    public void Delete(int id)
    {
        if (!DataSource.Volunteers!.Any(e => e.Id == id))
            throw new DalDeletionImpossible($"The Call Item with id {id} isn't exist");
        DataSource.Volunteers!.RemoveAll(e => e.Id == id);
    }
    public void DeleteAll()
    {
        DataSource.Volunteers!.Clear();
    }

    public Volunteer? Read(Func<Volunteer, bool> filter)
    {
        return DataSource.Volunteers!.FirstOrDefault(filter);
    }
}
