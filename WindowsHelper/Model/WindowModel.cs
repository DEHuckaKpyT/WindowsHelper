using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsHelper.Service.WindowService;

namespace WindowsHelper.Model
{
    internal class WindowModel
    {
        Rect rectangle;

        string processName;

        public Rect Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public string ProcessName
        {
            get { return processName; }
            set { processName = value; }
        }

        public WindowModel(Rect rectangle, string processName)
        {
            this.rectangle = rectangle;
            this.processName = processName;
        }

        public WindowModel()
        {
        }

        public override string? ToString()
        {
            return $"WindowModel-{processName}";
        }
    }
}