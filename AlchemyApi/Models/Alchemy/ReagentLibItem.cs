using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AlchemyApi.Models.Alchemy
{
    public class ReagentLibItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(0, 255)]
        public byte Red { get; set; }

        [Required]
        [Range(0, 255)]
        public byte Green { get; set; }

        [Required]
        [Range(0, 255)]
        public byte Blue { get; set; }

        public virtual ICollection<ReactionLibItem> FirstSourceReactions { get; set; }
        public virtual ICollection<ReactionLibItem> SecondSourceReactions { get; set; }
        public virtual ICollection<ReactionLibItem> ResultReactions { get; set; }

        public ReagentLibItem()
        {
            FirstSourceReactions = new List<ReactionLibItem>();
            SecondSourceReactions = new List<ReactionLibItem>();
            ResultReactions = new List<ReactionLibItem>();
        }

        public string GetColor()
        {
            // TODO: OPTIMIZE THIS
            StringBuilder builder = new StringBuilder(7);
            builder.Append("#");
            builder.AppendFormat("{0:x2}", Red);
            builder.AppendFormat("{0:x2}", Green);
            builder.AppendFormat("{0:x2}", Blue);
            System.Diagnostics.Debug.WriteLine(builder.ToString());
            return builder.ToString();
        }
    }
}