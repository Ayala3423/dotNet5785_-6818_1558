using DalApi;
using DO;
using System.Collections.Generic;

namespace Dal;
public class VolunteerImplementation : IVolunteer
{
    public void Create(Volunteer item)
    {
        if (item.Id)
        {
            if (DataSource.Volunteers.Any(e => e.Id == item.Id))
                throw new NotImplementedException($"The Call Item with id {item.id} is already exist");
            DataSource.Volunteers.Add(item);
        }
        else
        {
            Volunteer itemCopy = item;
            int newId = Config.NextAssignmentId; //לבדוק
            itemCopy.Id = newId;
            DataSource.Volunteers.Add(itemCopy);
            //return newId;
        }
    }
    public Volunteer? Read(int id)
    {
        Volunteer foundCall = DataSource.Volunteers.FirstOrDefault(e => e.Id == id);
        if (foundCall == null)
            return null;
        return foundCall;
    }
    public List<Volunteer> ReadAll()
    {
        return new List<Volunteer>(DataSource.Volunteers);
    }
    public void Update(Volunteer item)
    {

        if (!DataSource.Volunteers.Any(e => e.Id == item.Id))
            throw new NotImplementedException($"The Call Item with id {item.id} isn't exist");
        DataSource.Volunteers.RemovAll(e => e.Id == item.Id);
        DataSource.Volunteers.Add(item);

    }
    public void Delete(int id)
    {
        if (!DataSource.Volunteers.Any(e => e.Id == id))
            throw new NotImplementedException($"The Call Item with id {id} isn't exist");
        DataSource.Volunteers.RemovAll(e => e.Id == id);
    }
    public void DeleteAll()
    {
        DataSource.Volunteers.Clear();
    }
}
