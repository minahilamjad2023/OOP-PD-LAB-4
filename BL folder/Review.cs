using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.BL
{
    public class Review
    {
        private string name;
        private string review;

        public Review(string name, string review)
        {
            this.name = name;
            this.review = review;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getReview()
        {
            return review;
        }

        public void setReview(string review)
        {
            this.review = review;
        }
    }
}
