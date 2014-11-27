using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using testturistapp.Annotations;

namespace testturistapp.Model
{
   public class Rating
    {
        private string _name;
        private string _ratingComment;
        private string _ratingSjerner;

        public string Name
        {
            get { return _name; }
            set { _name = value;}
        }

        public string RatingComment
        {
            get { return _ratingComment; }
            set { _ratingComment = value;}
        }

        public string RatingSjerner
        {
            get { return _ratingSjerner; }
            set { _ratingSjerner = value;}
        }

        public Rating(string name, string ratingComment, string ratingSjerner)
        {
            _name = name;
            _ratingComment = ratingComment;
            _ratingSjerner = ratingSjerner;
        }

       public Rating()
       {
           
       }

        public override string ToString()
        {
            return _name;
        }

    }
}
