using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAP.Core.Entities;
using TAP.Services;
using TAP.Web.Areas.BlogArea.Models;
using Microsoft.AspNetCore.Identity;
using TAP.DataAccess;
using TAP.DataAccess.Repositories;
using TAP.Services.CommentServices;

namespace TAP.Web.Areas.BlogArea.Controllers
{
    public class BlogsController : Controller
    {
        /*private readonly UserManager<User> userManager;

        private readonly IBlogServices _blogService;
        // GET: BlogsController
        public BlogsController(IBlogServices blogServices)
        {
            _blogService = blogServices;
        }*/

        private readonly IBlogServices blogService;
        private readonly ICommentServices commentServices;
        private readonly UserManager<User> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDataRepository _daraRepository;

        public BlogsController(IUnitOfWork unitOfWork, IBlogServices blogService, ICommentServices commentServices, UserManager<User> userManager, IDataRepository dataRepository)
        {
            this.userManager = userManager;
            this.blogService = blogService;
            this.commentServices = commentServices;
            this.unitOfWork = unitOfWork;
            _daraRepository = dataRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserBlogs()
        {
            var userId = Guid.Parse(userManager.GetUserId(User));
            var blogs = await blogService.GetUserBlogsAsync(userId);
            return View("UserBlogs", new UserBlogsViewModel() { Blogs = blogs });
        }

        public async Task<IActionResult> AllBlogs()
        {
            var blogs = await blogService.GetBlogs();
            if (User.Identity.IsAuthenticated)
            {
                var userId = Guid.Parse(userManager.GetUserId(User));
                return View("AllBlogs", new AllBlogsViewModel() { Blogs = blogs, UserId = userId });
            }

            return View("AllBlogs", new AllBlogsViewModel() { Blogs = blogs});
        }

        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogCreateViewModel blogModel)
        {
            var blog = new Blog { Id = Guid.NewGuid(), Title = blogModel.BlogTitle, Content = blogModel.BlogContent, Author = userManager.GetUserName(User), UserId = Guid.Parse(userManager.GetUserId(User))};
            blogService.CreateBlog(blog);
            unitOfWork.Commit();
            return RedirectToAction("UserBlogs");
        }

        //[HttpDelete]
        public ActionResult DeleteBlog(string id, string title)
        {
            Guid userId = Guid.Parse(userManager.GetUserId(User));

            BlogDeleteViewModel viewModel = new BlogDeleteViewModel()
            {
                BlogTitle = title,
                UserId = userId,
                BlogId = Guid.Parse(id)
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteBlogAsync(BlogDeleteViewModel model)
        {
            try
            {
                var blog = await blogService.GetBlogAsync(model.BlogId);
               // if (model.UserId != blog.UserId)
               //     return Redirect("/");
                blogService.DeleteBlog(blog.Id);
                //blogService.DeleteBlog(model.BlogId);
                unitOfWork.Commit();
                if(User.Identity.IsAuthenticated)
                    return RedirectToAction("UserBlogs");
                return RedirectToAction("AllBlogs");
            }
            catch
            {
                return Redirect("/");
            }
        }

        public async Task<ActionResult> ViewBlog(Guid blogID)
        {
            var blog = await blogService.GetBlogAsync(blogID);
            var comments = await commentServices.GetBlogCommentsAsync(blogID);
            return View( "ViewBlog", new BlogViewModel() { blog2 = blog, Comments = comments } );
        }

        [HttpPost]
        public ActionResult EditPost(Blog blogModel)
        {
            if (blogModel != null)
            {
                blogService.EditBlog(blogModel);
            }
            return View();
        }
    }
}