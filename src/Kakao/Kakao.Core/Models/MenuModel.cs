using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Core.Models
{
    public class MenuModel
    {
        public string Id { get; set; }

        public MenuModel DataGetn(string id)
        {
            Id = id;

            return this;
        }
    }
}
