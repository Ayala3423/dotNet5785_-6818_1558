using DalApi;
using DO;

namespace Dal;

internal class ConfigImplementation : IConfig
{
    public DateTime Clock { get => throw new DalNotImplementedProperty("The Property does not Implemented"); set => throw new DalNotImplementedProperty("The Property does not Implemented"); }

    public int NextCallId => throw new DalNotImplementedProperty("The Property does not Implemented");

    public int NextAssignmentId => throw new DalNotImplementedProperty("The Property does not Implemented");

    public void Reset()
    {
        throw new DalNotImplementedProperty("The Property does not Implemented");
    }
}