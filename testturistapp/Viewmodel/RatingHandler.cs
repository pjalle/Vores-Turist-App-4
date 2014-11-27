using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;
using testturistapp.Annotations;
using testturistapp.Model;
using testturistapp.Common;

namespace testturistapp.Viewmodel
{
  public class RatingHandler : INotifyPropertyChanged
    {
      private string _name;
      private string _comment;
      private string _ratingStjerner;
      private Rating _selectedRating;

      public Kategori selectedKategori { get; set; }

      public Rating selectedRating
      {
          get { return _selectedRating; }
          set { _selectedRating = value; OnPropertyChanged("selectedRating"); }
      }

      public void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name) || 30 < name.Length)
            {
                throw new ArgumentException("N");
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public string RatingStjerner
        {
            get { return _ratingStjerner; }
            set { _ratingStjerner = value; }
        }

        /*public RatingHandler(Kategori selectedKategori)
        {
            this.selectedKategori = selectedKategori;
        }*/

        public void opretRating()
        {
            Rating r = new Rating(_name,_comment,_ratingStjerner);
            selectedKategori.Vurderinger.Add(r);
            
        }

        public RatingHandler()
        {
          

        }

        public void sletRating()
        {
            selectedKategori.Vurderinger.Remove(selectedRating);
        }

      #region Notify

      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
      }

      #endregion

        private MainViewModel mainViewModel;

        public RatingHandler(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public void AddRatings()
        {
            mainViewModel.AddRatings();
        }

        public async void SaveRatingsAsync()
        {
            PersistenceFacade.SaveRatingsAsXmlAsync(mainViewModel.Ratings);
        }

        public async void LoadRatingsAsync()
        {
            ObservableCollection<Rating> ratings = await PersistenceFacade.LoadRatingsFromXmlAsync();
            mainViewModel.Ratings.Clear();
            foreach (var rating in ratings)
            {
             mainViewModel.Ratings.Add(rating);   
            }
        }
    }
}
