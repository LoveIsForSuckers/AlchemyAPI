using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlchemyApi.Models.Alchemy
{
    public class ReactionLibItem
    {
        public int Id { get; set; }

        [ForeignKey("FirstSourceReagentLibItem")]
        public int? FirstSourceReagentLibItemId { get; set; }

        [ForeignKey("SecondSourceReagentLibItem")]
        public int? SecondSourceReagentLibItemId { get; set; }

        [ForeignKey("ResultReagentLibItem")]
        public int? ResultReagentLibItemId { get; set; }

        //[ForeignKey("FirstSourceReagentLibItemId")]
        public virtual ReagentLibItem FirstSourceReagentLibItem { get; set; }

        //[ForeignKey("SecondSourceReagentLibItemId")]
        public virtual ReagentLibItem SecondSourceReagentLibItem { get; set; }

        //[ForeignKey("ResultReagentLibItemId")]
        public virtual ReagentLibItem ResultReagentLibItem { get; set; }

        public string GetFullString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(FirstSourceReagentLibItem.Title);
            builder.Append(" + ");
            builder.Append(SecondSourceReagentLibItem.Title);
            builder.Append(" = ");
            builder.Append(ResultReagentLibItem.Title);
            return builder.ToString();
        }
    }
}