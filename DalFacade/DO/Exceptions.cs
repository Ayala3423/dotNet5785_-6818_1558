using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

[Serializable]
public class DalDoesNotExistException : Exception //The user is not exist
{
    public DalDoesNotExistException(string? message) : base(message) { }
}

public class DalAlreadyExistsException : Exception
{
    public DalAlreadyExistsException(string? message) : base(message) { }
}

public class DalDeletionImpossible : Exception
{
    public DalDeletionImpossible(string? message) : base(message) { }
}
public class DalNotImplementedProperty : Exception
{
    public DalNotImplementedProperty(string? message) : base(message) { }
}

