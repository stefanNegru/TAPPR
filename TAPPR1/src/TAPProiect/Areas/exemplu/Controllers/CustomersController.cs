using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAP.Web.Models;


using TAP.Core.Entities;
using TAP.Services;
using TAP.Web.Areas.exemplu.Models;
using Microsoft.AspNetCore.Identity;
using TAP.DataAccess;
using TAP.DataAccess.Repositories;

namespace TAP.Web.Areas.exemplu.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IBlogServices blogService;
        private readonly UserManager<User> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDataRepository _daraRepository;


        public CustomersController(IUnitOfWork unitOfWork, IBlogServices blogService, UserManager<User> userManager, IDataRepository dataRepository)
        {
            this.userManager = userManager;
            this.blogService = blogService;
            this.unitOfWork = unitOfWork;
            _daraRepository = dataRepository;
        }
        public async Task<IActionResult> UserBlogs()
        {
            var userId = Guid.Parse(userManager.GetUserId(User));
            var blogs = await blogService.GetUserBlogsAsync(userId);
            return View("UserBlogs", new UserBlogsViewModel() { Blogs = blogs });
        }



        public IActionResult CreateBlog()
        {
            return View(new CreateBlogViewModel());
            //return View();
        }

        [HttpPost]
        public IActionResult CreateBlog(CreateBlogViewModel blogModel)
        {
            var blog = new Blog { Id = Guid.NewGuid(), Title = blogModel.BlogTitle, Content = blogModel.BlogContent, Author = blogModel.AuthorName};
            System.Console.WriteLine(blogModel.AuthorName);
            blogService.CreateBlog(blog);
            unitOfWork.Commit();
            return RedirectToAction("UserBlogs");
            
            //return View(blogModel);

        }




        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult ex1()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCustomerModel model)
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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

        public ActionResult SayHello()
        {
            //return Content($"Hello");
            return View();
        }
    }
}
