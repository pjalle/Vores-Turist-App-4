using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using testturistapp.Annotations;
using testturistapp.Common;
using testturistapp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using testturistapp.Common;

namespace testturistapp.Viewmodel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public string RatingComment
        {
            get { return _ratingComment; }
            set { _ratingComment = value; OnPropertyChanged(); }
        }

        public string RatingStjerner
        {
            get { return _ratingStjerner; }
            set { _ratingStjerner = value; OnPropertyChanged(); }
        }

        private ICommand _addCommand;
        private ICommand _saveCommand;
        private ICommand _loadCommand;
        private string _name;
        private string _ratingComment;
        private string _ratingStjerner;

        public ObservableCollection<Rating> Ratings { get; set; }

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(RatingHandler.AddRatings);
                return _addCommand;
            }
            set { _addCommand = value; }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(RatingHandler.SaveRatingsAsync); 
                return _saveCommand;
            }
            set { _saveCommand = value; }
        }

        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                    _loadCommand = new RelayCommand(RatingHandler.LoadRatingsAsync);
                return _loadCommand;
            }
            set { _loadCommand = value; }
        }

        public RatingHandler RatingHandler { get; set; }

        public void AddRatings()
        {
            Ratings.Add(new Rating(_name, _ratingComment, _ratingStjerner));
            Name = "";
            RatingComment = "";
            RatingStjerner = "";
        }

        private Kategori rosTorv = new Kategori("Ro's Torv", "Ro's Torv ligger i Roskilde og er et unikt shoppingcenter med fokus på design, kunst og arkitektur. De lyse og smukke omgivelser skaber en stemning og stil, som gør det til en særlig oplevelse at besøge centret.", "ms-appx:///assets/rostorv.jpg", "ms-appx:///assets/RosTorv2.jpg");
        private Kategori vikingeMuseum = new Kategori("Vikingeskibsmuseum", "Vikingeskibsmuseet i Roskilde er Danmarks museum for skibe, søfart og bådbygningskultur i oldtid og middelalder.", "ms-appx:///assets/vikingemuseet.jpg", "ms-appx:///assets/VikingeMuseet2.jpg");
        private Kategori cafeVivaldi = new Kategori("Cafe Vivaldi", "I Roskildes 2 hjerter finder du de to Vivaldi Caféer. Caféerne kan du finde på gågaden tæt ved domkirken, og på Ro’s Torv - Roskilde fantastiske shoppingcenter. I caféerne er der lagt vægt på lyse og hyggelige omgivelser, hvor du virkelig føler dig hjemme.", "ms-appx:///assets/vivaldi.jpg", "ms-appx:///assets/CafeVivaldi2.jpg");

        private ObservableCollection<Kategori> _kategoriviser;
        static RatingHandler _rating;
        private static Kategori _selectedKategori;
        private RelayCommand _opretRatingCommand;
        private RelayCommand _removeRatingCommand;
        private Rating _selectedRating;

        public ObservableCollection<Kategori> Kategoriviser
        {
            get { return _kategoriviser; }
            set { _kategoriviser = value; }
        }

        public Rating SelectedRating
        {
            get { return _selectedRating; }
            set
            {
                if (Equals(value, _selectedRating)) return;
                _selectedRating = value;
                OnPropertyChanged();
            }
        }

        public RatingHandler Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        public RelayCommand OpretRatingCommand
        {
            get { return _opretRatingCommand; }
            set { _opretRatingCommand = value; }
        }
        public RelayCommand RemoveRatingCommand
        {
            get { return _removeRatingCommand; }
            set { _removeRatingCommand = value; }
        }
        public Kategori CafeVivaldi
        {
            get { return cafeVivaldi; }
            set { cafeVivaldi = value; }
        }

        public Kategori VikingeMuseum
        {
            get { return vikingeMuseum; }
            set { vikingeMuseum = value; }
        }

        public Kategori RosTorv
        {
            get { return rosTorv; }
            set { rosTorv = value; }
        }

        public static Kategori SelectedKategori
        {
            get { return _selectedKategori; }
            set { _selectedKategori = value;}
        }

        public override string ToString()
        {
            return string.Format("CafeVivaldi: {0}, VikingeMuseum: {1}, RosTorv: {2}", cafeVivaldi, vikingeMuseum, rosTorv);
        }

        public MainViewModel()
        {
            Ratings = new ObservableCollection<Rating>();
            RatingHandler = new RatingHandler(this);

            _kategoriviser = new ObservableCollection<Kategori>();
            _kategoriviser.Add(rosTorv);
            rosTorv.Vurderinger.Add(new Rating("Daniel", "god", "5"));

            _kategoriviser.Add(vikingeMuseum);
            vikingeMuseum.Vurderinger.Add(new Rating("Bjarke", "flotte skibe", "4"));

            _kategoriviser.Add(cafeVivaldi);
            cafeVivaldi.Vurderinger.Add(new Rating("Ebu Gosling", "Total Næver", "10"));
        }

        #region Notifychanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));

            #endregion

        
        }
        }
    }
