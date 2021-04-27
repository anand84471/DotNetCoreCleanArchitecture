using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.HttpRequest
{
    public class SearchRequestBase
    {
        [Required]
        [Display(Name = "key")]
        public string SearchString { get; set; }
        [Required]
        [Display(Name = "no_of_rows_fetched")]
        public int NoOfRowsFectched { get; set; }
        [Display(Name = "max_rows_to_be_fetched")]
        public int MaxRowsToBeFectched { get; set; }
    }
}
