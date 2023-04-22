using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaluLibrary.Exception;

public class InvalidDocumentException : System.Exception
{
    public string PropertyName { get; }
    public InvalidDocumentException(string message, string propertyName) : base(message)
    {
        PropertyName = propertyName;
    }
}
