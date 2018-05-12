using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueRibbonsReview.Models
{
    public class Review
    {
        public Guid ReviewID { get; set; }
        public DateTime ReviewDate { get; set; }
        public int? ProductRating { get; set; }
        public string ReviewDetails { get; set; }
        public string UserId { get; set; }

        public int? CampaignId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Campaign Campaign { get; set; }

    }
}