using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To.Do {
    [Serializable]
    internal class Task {
        public string Title { get; set; }
        public string Status { get; set; }
        public string Project { get; set; }
        public DateTime DueDate { get; set; }
    }
}
