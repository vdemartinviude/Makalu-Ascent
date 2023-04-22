using MakaluLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaluTests.TestUtils;

public class SourceAddressJson : ISourceJson
{
    public string Street { get; set; }  
    public string City { get; set; }
    public string PostalCode { get; set; }  
    public string Country { get; set; }
}
