using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

// Exception thrown when the requested entity does not exist
[Serializable]
public class DalDoesNotExistException : Exception
{
    public DalDoesNotExistException(string? message) : base(message) { }
}

// Exception thrown when an entity already exists
public class DalAlreadyExistsException : Exception
{
    public DalAlreadyExistsException(string? message) : base(message) { }
}

// Exception thrown when a deletion operation is not possible
public class DalDeletionImpossible : Exception
{
    public DalDeletionImpossible(string? message) : base(message) { }
}

// Exception thrown when a property or method is not implemented
public class DalNotImplementedProperty : Exception
{
    public DalNotImplementedProperty(string? message) : base(message) { }
}
