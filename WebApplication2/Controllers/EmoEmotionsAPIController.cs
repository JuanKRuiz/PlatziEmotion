using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmoEmotionsAPIController : ApiController
    {
        private WebApplication2Context db = new WebApplication2Context();

        // GET: api/EmoEmotionsAPI
        public IQueryable<EmoEmotion> GetEmoEmotions()
        {
            return db.EmoEmotions;
        }

        // GET: api/EmoEmotionsAPI/5
        [ResponseType(typeof(EmoEmotion))]
        public IHttpActionResult GetEmoEmotion(int id)
        {
            EmoEmotion emoEmotion = db.EmoEmotions.Find(id);
            if (emoEmotion == null)
            {
                return NotFound();
            }

            return Ok(emoEmotion);
        }

        // PUT: api/EmoEmotionsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmoEmotion(int id, EmoEmotion emoEmotion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emoEmotion.Id)
            {
                return BadRequest();
            }

            db.Entry(emoEmotion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmoEmotionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmoEmotionsAPI
        [ResponseType(typeof(EmoEmotion))]
        public IHttpActionResult PostEmoEmotion(EmoEmotion emoEmotion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmoEmotions.Add(emoEmotion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emoEmotion.Id }, emoEmotion);
        }

        // DELETE: api/EmoEmotionsAPI/5
        [ResponseType(typeof(EmoEmotion))]
        public IHttpActionResult DeleteEmoEmotion(int id)
        {
            EmoEmotion emoEmotion = db.EmoEmotions.Find(id);
            if (emoEmotion == null)
            {
                return NotFound();
            }

            db.EmoEmotions.Remove(emoEmotion);
            db.SaveChanges();

            return Ok(emoEmotion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmoEmotionExists(int id)
        {
            return db.EmoEmotions.Count(e => e.Id == id) > 0;
        }
    }
}