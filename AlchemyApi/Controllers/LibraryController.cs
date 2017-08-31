using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using AlchemyApi.Models.Alchemy;

namespace AlchemyApi.Controllers
{
    public class LibraryController : ApiController
    {
        ReagentLibContext db = new ReagentLibContext();

        public IHttpActionResult Get()
        {
            var viewmodel = new LibraryViewModel();
            var reactionDBList = db.Reactions.ToList();
            var reagentDBList = db.Reagents.ToList();
            viewmodel.Reactions = reactionDBList.ConvertAll<Reaction>(r => new Reaction(r));
            viewmodel.Reagents = reagentDBList.ConvertAll<Reagent>(r => new Reagent(r));
            return Ok(viewmodel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
