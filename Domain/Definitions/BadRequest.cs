using System.Runtime.InteropServices;

namespace OneOf.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct BadRequest
    {
        public BadRequest(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}