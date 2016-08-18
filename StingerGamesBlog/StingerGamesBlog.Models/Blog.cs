using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StingerGamesBlog.Models
{
    public class Blog
    {   
        public int BlogId { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string Content { get; set; }
        public DateTime BlogDate {get;set;}
        public string Author { get; set; }
        public List<Tag> Tags { get; set; }
        public bool IsApproved { get; set; }
    }
}