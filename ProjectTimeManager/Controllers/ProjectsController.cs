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
using ProjectTimeManager.Models;

namespace ProjectTimeManager.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectRepository ProjectDb = new ProjectRepository();
        private readonly TimeTrackRepository TimeTrackDb = new TimeTrackRepository();

        // GET: Projects
        public ActionResult Index()
        {
            var projectTimeTrack = TimeTrackDb.GetList();

            List<ProjectTimeVM> projectStat = new List<ProjectTimeVM>();
            foreach (var project in projectTimeTrack)
            {
                TimeSpan timeTrack = new TimeSpan();
                if (!projectStat.Any(p => p.Project_ID == project.Project_ID))
                {
                    projectStat.Add(new ProjectTimeVM
                    {
                        Project_ID = project.Project_ID,
                        ProjectName = project.Project.Name,
                        TimeSpent = project.EndTime - project.StartTime
                    });
                }
                else {
                    ProjectTimeVM tempProject = projectStat.Where(p => p.Project_ID == project.Project_ID).FirstOrDefault();
                    tempProject.TimeSpent += project.EndTime - project.StartTime;
                }
                
            }

            return View(projectStat);
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = ProjectDb.Find(id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Project project)
        {
            if (ModelState.IsValid)
            {
                ProjectDb.Add(project);
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = ProjectDb.Find(id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Project project)
        {
            var model = ProjectDb.Find(project.ID);
            bool isOk = TryUpdateModel(model);
            if (ModelState.IsValid && isOk)
            {
                ProjectDb.Update(model);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = ProjectDb.Find(id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = ProjectDb.Find(id);
            bool ok = ProjectDb.Delete(id);
            if (ok)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Delete", id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ProjectDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
