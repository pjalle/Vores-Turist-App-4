using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using testturistapp.Annotations;

namespace testturistapp.Model
{
    public class Kategori 
    {
        private string _navn;
        private string _beskrivelse;
        private string _billede;
        private string _billede2;

        private ObservableCollection<Rating> _vurderinger;

        public ObservableCollection<Rating> Vurderinger
        {
            get { return _vurderinger; }
            set { _vurderinger = value; }
        }

        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        public string Beskrivelse
        {
            get { return _beskrivelse; }
            set { _beskrivelse = value; }
        }

        public string Billede
        {
            get { return _billede; }
            set { _billede = value; }
        }

        public string Billede2
        {
            get { return _billede2; }
            set { _billede2 = value; }
        }

        public Kategori(string navn, string beskrivelse, string billede, string billede2)
        {
            _navn = navn;
            _beskrivelse = beskrivelse;
            _billede = billede;
            _billede2 = billede2;
            _vurderinger = new ObservableCollection<Rating>();
        }

        public override string ToString()
        {
            return _navn;
        }
    }
}
