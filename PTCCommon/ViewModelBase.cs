using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCCommon
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Init();

        }
        public string EventCommand { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }

        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }

        protected virtual void ListMode() //moved from TrainingProdcutViewModel changed from private to protected so we can inherit from it, and virtual so we can override it.
        {
            IsValid = true;

            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "List";
        }


        protected virtual void Init()
        {
            EventCommand = "List";
            EventArgument = string.Empty;

            ValidationErrors = new List<KeyValuePair<string, string>>();
            ListMode();

        }
    }
}
