using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StingerGamesBlog.Models {

    public class TinyMCEModelVM {

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string Content { get; set; }
        public string Title { get; set; }
    }
}