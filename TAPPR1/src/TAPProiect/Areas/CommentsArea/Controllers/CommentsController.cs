using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAP.Web.Areas.CommentsArea.Models;
using TAP.Core.Entities;


using TAP.Services;
using TAP.Services.CommentServices;
using TAP.Web.Areas.BlogArea.Models;
using Microsoft.AspNetCore.Identity;
using TAP.DataAccess;
using TAP.DataAccess.Repositories;
using TAP.Web.Areas.BlogArea.Controllers;

//using System.Web.Routing;

namespace TAP.Web.Areas.CommentsArea.Controllers
{
    public class CommentsController : Controller
    {
        // GET: CommentsController

        private readonly ICommentServices commentServices;
        private readonly UserManager<User> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDataRepository _daraRepository;

        public CommentsController(IUnitOfWork unitOfWork, ICommentServices commentServices, UserManager<User> userManager, IDataRepository dataRepository)
        {
            this.userManager = userManager;
            this.commentServices = commentServices;
            this.unitOfWork = unitOfWork;
            _daraRepository = dataRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: CommentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommentsController/Create
        public ActionResult Create(Guid blogId)
        {
            return View(new CommentCreateViewModel() {blogID = blogId } );
        }

        // POST: CommentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreateViewModel blogModel)
        {
            var comment = new Comment { Id = Guid.NewGuid(), Content = blogModel.CommentContent , Author = userManager.GetUserName(User), AuthorId = Guid.Parse(userManager.GetUserId(User)), BlogId = blogModel.blogID};
            commentServices.CreateComment(comment);
            unitOfWork.Commit();

            return RedirectToAction("ViewBlog", "Blogs", new { blogID = blogModel.blogID });
        }

        // GET: CommentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
