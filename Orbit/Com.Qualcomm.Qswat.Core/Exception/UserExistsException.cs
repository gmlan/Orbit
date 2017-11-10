using System.Runtime.Serialization;

namespace Com.Qualcomm.Qswat.Core.Exception
{
    public class UserExistsException : System.Exception
    {
        public UserExistsException(string msg) : base(msg) { }

        public UserExistsException(string msg, System.Exception ex) : base(msg, ex) { }

        public UserExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
