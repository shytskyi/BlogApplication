using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServiceLayer.Enum
{
    public class Enum
    {
        public enum FilterTypeToOrder
        {
            [Display(Name = "sort by...")] SimpleOrder = 0,
            [Display(Name = "Number Star ↑")] ByVotes,
            [Display(Name = "Publication Date ↑")] ByPublicationDate
        }

        public enum SortFilterBy
        {
            [Display(Name = "All")] NoFilter = 0,
            [Display(Name = "By Average Stars")] ByAverageStars,
            [Display(Name = "By Categories")] ByTags,
            [Display(Name = "By Year published")] ByPublicationYear
        }
    }
}
