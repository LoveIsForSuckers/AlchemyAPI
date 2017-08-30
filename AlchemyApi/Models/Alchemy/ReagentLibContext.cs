using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AlchemyApi.Models.Alchemy
{
    public class ReagentLibContext : DbContext
    {
        public ReagentLibContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<ReagentLibItem> Reagents { get; set; }
        public DbSet<ReactionLibItem> Reactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReactionLibItem>().HasRequired(reaction => reaction.FirstSourceReagentLibItem).WithMany(reagent => reagent.FirstSourceReactions).HasForeignKey(reaction => reaction.FirstSourceReagentLibItemId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ReactionLibItem>().HasRequired(reaction => reaction.SecondSourceReagentLibItem).WithMany(reagent => reagent.SecondSourceReactions).HasForeignKey(reaction => reaction.SecondSourceReagentLibItemId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ReactionLibItem>().HasRequired(reaction => reaction.ResultReagentLibItem).WithMany(reagent => reagent.ResultReactions).HasForeignKey(reaction => reaction.ResultReagentLibItemId).WillCascadeOnDelete(false);
        }
    }
}