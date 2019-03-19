using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController.Tests.Mocks
{
    interface IMessageService
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
