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

namespace ProjectTimeManager.Controllers
{
    public class ProjectMembersController : Controller
    {
        private readonly ProjectTimeManagerDbContext db = new ProjectTimeManagerDbContext();

        // GET: ProjectMembers
        public ActionResult Index()
        {
            var projectMember = db.ProjectMember.Include(p => p.Person).Include(p => p.Project);
            return View(projectMember.ToList());
        }

        // GET: ProjectMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectMember projectMember = db.ProjectMember.Find(id);
            if (projectMember == null)
            {
                return HttpNotFound();
            }
            return View(projectMember);
        }

        // GET: ProjectMembers/Create
        public ActionResult Create()
        {
            ViewBag.Person_ID = new SelectList(db.Person, "ID", "Name");
            ViewBag.Project_ID = new SelectList(db.Project, "ID", "Name");
            return View();
        }

        // POST: ProjectMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Project_ID,Person_ID,CreatedAt,UpdatedAt")] ProjectMember projectMember)
        {
            if (ModelState.IsValid)
            {
                db.ProjectMember.Add(projectMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Person_ID = new SelectList(db.Person, "ID", "Name", projectMember.Person_ID);
            ViewBag.Project_ID = new SelectList(db.Project, "ID", "Name", projectMember.Project_ID);
            return View(projectMember);
        }

        // GET: ProjectMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectMember projectMember = db.ProjectMember.Find(id);
            if (projectMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.Person_ID = new SelectList(db.Person, "ID", "Name", projectMember.Person_ID);
            ViewBag.Project_ID = new SelectList(db.Project, "ID", "Name", projectMember.Project_ID);
            return View(projectMember);
        }

        // POST: ProjectMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Project_ID,Person_ID,CreatedAt,UpdatedAt")] ProjectMember projectMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Person_ID = new SelectList(db.Person, "ID", "Name", projectMember.Person_ID);
            ViewBag.Project_ID = new SelectList(db.Project, "ID", "Name", projectMember.Project_ID);
            return View(projectMember);
        }

        // GET: ProjectMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectMember projectMember = db.ProjectMember.Find(id);
            if (projectMember == null)
            {
                return HttpNotFound();
            }
            return View(projectMember);
        }

        // POST: ProjectMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectMember projectMember = db.ProjectMember.Find(id);
            db.ProjectMember.Remove(projectMember);
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
