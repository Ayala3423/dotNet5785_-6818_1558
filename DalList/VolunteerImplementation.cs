using DalApi;
using DO;
using System.Collections.Generic;

namespace Dal;
public class VolunteerImplementation : IVolunteer
{
    public void Create(Volunteer item)
    {
        
            if (DataSource.Volunteers.Any(e => e.Id == item.Id))
                throw new NotImplementedException($"The Call Item with id {item.Id} is already exist");
            DataSource.Volunteers.Add(item);
       
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
            throw new NotImplementedException($"The Call Item with id {item.Id} isn't exist");
        DataSource.Volunteers.RemoveAll(e => e.Id == item.Id);
        DataSource.Volunteers.Add(item);

    }
    public void Delete(int id)
    {
        if (!DataSource.Volunteers.Any(e => e.Id == id))
            throw new NotImplementedException($"The Call Item with id {id} isn't exist");
        DataSource.Volunteers.RemoveAll(e => e.Id == id);
    }
    public void DeleteAll()
    {
        DataSource.Volunteers.Clear();
    }
}
