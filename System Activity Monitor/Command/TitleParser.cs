using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Activity_Monitor.Command
{
    public class TitleParser
    {
        public string Title { get; set; }
      
        public TitleParser()
        {

        }

        public void ParseTitle(string title)
        {
            Title = title;
        }
        
    }
}
