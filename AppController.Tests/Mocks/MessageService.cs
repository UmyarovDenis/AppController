using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController.Tests.Mocks
{
    class MessageService : IMessageService
    {
        public int Id { get; set; }
        public string Name { get; set; } = "MyService";
    }
}
