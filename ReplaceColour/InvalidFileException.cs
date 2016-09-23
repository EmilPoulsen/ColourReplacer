using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ReplaceColour
{

    [Serializable]
    public class InvalidFileException : Exception
    {
public InvalidFileException()
        : base() { }
    
    public InvalidFileException(string message)
        : base(message) { }
    
    public InvalidFileException(string format, params object[] args)
        : base(string.Format(format, args)) { }
    
    public InvalidFileException(string message, Exception innerException)
        : base(message, innerException) { }
    
    public InvalidFileException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }

    protected InvalidFileException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
    }
}
