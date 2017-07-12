using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectTimeManager.DAL;
using ProjectTimeManager.Model;
using ProjectTimeManager.DAL.Repository;

namespace ProjectTimeManager.Controllers
{
    public class TimeTracksController : Controller
    {
        private readonly TimeTrackRepository TimeTrackDb = new TimeTrackRepository();
        private readonly PersonRepository PersonDb = new PersonRepository();
        private readonly ProjectRepository ProjectDb = new ProjectRepository();

        // GET: TimeTracks
        public ActionResult Index()
        {
            return View(TimeTrackDb.GetList());
        }

        // GET: TimeTracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTrack timeTrack = TimeTrackDb.Find(id.Value);
            if (timeTrack == null)
            {
                return HttpNotFound();
            }
            return View(timeTrack);
        }

        // GET: TimeTracks/Create
        public ActionResult Create()
        {
            ViewBag.Person_ID = new SelectList(PersonDb.GetList(), "ID", "Name");
            ViewBag.Project_ID = new SelectList(ProjectDb.GetList(), "ID", "Name");
            return View();
        }

        // POST: TimeTracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Project_ID,Person_ID,StartTime,EndTime")] TimeTrack timeTrack)
        {
            if (ModelState.IsValid)
            {
                TimeTrackDb.Add(timeTrack);
                return RedirectToAction("Index");
            }

            ViewBag.Person_ID = new SelectList(PersonDb.GetList(), "ID", "Name", timeTrack.Person_ID);
            ViewBag.Project_ID = new SelectList(ProjectDb.GetList(), "ID", "Name", timeTrack.Project_ID);
            return View(timeTrack);
        }

        // GET: TimeTracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTrack timeTrack = TimeTrackDb.Find(id.Value);
            if (timeTrack == null)
            {
                return HttpNotFound();
            }
            ViewBag.Person_ID = new SelectList(PersonDb.GetList(), "ID", "Name", timeTrack.Person_ID);
            ViewBag.Project_ID = new SelectList(ProjectDb.GetList(), "ID", "Name", timeTrack.Project_ID);
            return View(timeTrack);
        }

        // POST: TimeTracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Project_ID,Person_ID,StartTime,EndTime")] TimeTrack timeTrack)
        {
            bool isOk = TryUpdateModel(timeTrack);
            if (ModelState.IsValid && isOk)
            {
                TimeTrackDb.Update(timeTrack);
                return RedirectToAction("Index");
            }
            ViewBag.Person_ID = new SelectList(PersonDb.GetList(), "ID", "Name", timeTrack.Person_ID);
            ViewBag.Project_ID = new SelectList(ProjectDb.GetList(), "ID", "Name", timeTrack.Project_ID);
            return View(timeTrack);
        }

        // GET: TimeTracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTrack timeTrack = TimeTrackDb.Find(id.Value);
            if (timeTrack == null)
            {
                return HttpNotFound();
            }
            return View(timeTrack);
        }

        // POST: TimeTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeTrack timeTrack = TimeTrackDb.Find(id);
            bool ok = TimeTrackDb.Delete(id);
            if (ok)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Delete", id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                TimeTrackDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
