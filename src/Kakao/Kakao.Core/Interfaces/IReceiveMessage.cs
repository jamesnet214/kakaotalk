using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Core.Interfaces
{
    public interface IReceiveMessage
    {
        void Received(string sendText);
    }
}
