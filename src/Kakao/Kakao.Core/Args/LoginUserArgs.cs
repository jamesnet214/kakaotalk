using Kakao.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Core.Args
{
    public class LoginUserArgs : EventArgs
    {
        public MessageModel Message { get; set; }
    }
}
