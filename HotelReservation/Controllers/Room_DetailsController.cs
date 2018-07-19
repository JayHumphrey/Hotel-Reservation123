using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelReservation.Models;

namespace HotelReservation.Controllers
{
    public class Room_DetailsController : Controller
    {
        private OnlineHotelReservationEntities db = new OnlineHotelReservationEntities();

        // GET: /Room_Details/
        public ActionResult Index()
        {
            var room_details = db.ROOM_DETAILS.Include(r => r.ROOM_TYPE_INFO);
            return View(room_details.ToList());
        }

        // GET: /Room_Details/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM_DETAILS room_details = db.ROOM_DETAILS.Find(id);
            if (room_details == null)
            {
                return HttpNotFound();
            }
            return View(room_details);
        }

        // GET: /Room_Details/Create
        public ActionResult Create()
        {
            ViewBag.ROOM_TYPE = new SelectList(db.ROOM_TYPE_INFO, "ROOM_TYPE", "ROOM_TYPE");//desciption
            return View();
        }

        // POST: /Room_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ROOM_ID,ROOM_TYPE,TOTAL_ROOMS,STATUS")] ROOM_DETAILS room_details)
        {
            if (ModelState.IsValid)
            {
                db.ROOM_DETAILS.Add(room_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ROOM_TYPE = new SelectList(db.ROOM_TYPE_INFO, "ROOM_TYPE", "ROOM_TYPE", room_details.ROOM_TYPE);//description
            return View(room_details);
        }

        // GET: /Room_Details/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM_DETAILS room_details = db.ROOM_DETAILS.Find(id);
            if (room_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.ROOM_TYPE = new SelectList(db.ROOM_TYPE_INFO, "ROOM_TYPE", "ROOM_TYPE", room_details.ROOM_TYPE);//description
            return View(room_details);
        }

        // POST: /Room_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ROOM_ID,ROOM_TYPE,TOTAL_ROOMS,STATUS")] ROOM_DETAILS room_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ROOM_TYPE = new SelectList(db.ROOM_TYPE_INFO, "ROOM_TYPE", "ROOM_TYPE", room_details.ROOM_TYPE);//DESCRIPTION
            return View(room_details);
        }

        // GET: /Room_Details/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM_DETAILS room_details = db.ROOM_DETAILS.Find(id);
            if (room_details == null)
            {
                return HttpNotFound();
            }
            return View(room_details);
        }

        // POST: /Room_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ROOM_DETAILS room_details = db.ROOM_DETAILS.Find(id);
            db.ROOM_DETAILS.Remove(room_details);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
