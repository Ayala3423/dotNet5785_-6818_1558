﻿namespace DalApi;
using DO;

public interface ICrud<T> where T : class
{
    void Create(T item); //Creates new entity object in DAL
    T? Read(int id); //Reads entity object by its ID
    IEnumerable<T> ReadAll(Func<T, bool>? filter = null); void Update(T item); //Updates entity object
    void Delete(int id); //Deletes an object by its Id
    void DeleteAll(); //Delete all entity objects
    T? Read(Func<T, bool> filter); //Reads entity object by conditional function
}
