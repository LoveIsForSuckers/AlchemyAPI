using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlchemyApi.Models.Alchemy
{
    public class LibraryViewModel
    {
        public IEnumerable<Reagent> Reagents { get; set; }

        public IEnumerable<Reaction> Reactions { get; set; }
    }

    public class Reaction
    {
        public Reaction(ReactionLibItem libitem)
        {
            Id = libitem.Id;
            FirstSourceReagentId = libitem.FirstSourceReagentLibItemId;
            SecondSourceReagentId = libitem.SecondSourceReagentLibItemId;
            ResultReagentId = libitem.ResultReagentLibItemId;
        }

        public int Id { get; set; }

        public int? FirstSourceReagentId { get; set; }

        public int? SecondSourceReagentId { get; set; }

        public int? ResultReagentId { get; set; }
    }

    public class Reagent
    {
        public Reagent(ReagentLibItem libitem)
        {
            Id = libitem.Id;
            Title = libitem.Title;
            Red = libitem.Red;
            Green = libitem.Green;
            Blue = libitem.Blue;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }
    }
}