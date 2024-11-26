using DalApi;

namespace Dal;

public class ConfigImplementation : IConfig
{
    public DateTime Clock { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int NextCalled => throw new NotImplementedException();

    public void Reset()
    {
        throw new NotImplementedException();
    }
}