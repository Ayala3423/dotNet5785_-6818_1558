namespace DalApi;

public interface IConfig
{
    DateTime Clock { get; set; }
    int NextCalled { get; }

    //...
    void Reset();

}
