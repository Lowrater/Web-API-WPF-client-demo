using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIFetcherClientTest.Models
{
    public class MainModel
    {
        private ObservableCollection<string> __personList = new ObservableCollection<string>();
        public ref ObservableCollection<string> _personList => ref __personList;

        private int __IdInput;
        public ref int _IdInput => ref __IdInput;

    }
}
