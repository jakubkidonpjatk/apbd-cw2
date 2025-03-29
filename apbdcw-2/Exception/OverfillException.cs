using System.Runtime.InteropServices;

namespace apbdcw_2.Exception;
public class OverfillException : System.Exception
{
    public OverfillException(string m) : base(m){}
}