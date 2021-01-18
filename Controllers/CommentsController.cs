using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PANDA_MVC_V5.Models;
using PANDA_MVC_V5.ViewModels;

namespace PANDA_MVC_V5.Controllers
{
    
    public class CommentsController : Controller
    {
        private BD_PANDA_STACK_Entities dbContext = new BD_PANDA_STACK_Entities();
        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetUsers(string username)
        {
            USUARIO user = dbContext.USUARIO.Where(u => u.USERNAME.ToLower() == username.ToLower())
                                 .FirstOrDefault();

            if (user != null)
            {
                Session["USERNAME"] = user.USERNAME;
                return RedirectToAction("GetPosts");
            }

            ViewBag.Msg = "Username does not exist !";
            return View();
        }
        
        [HttpGet]
        public ActionResult GetPosts()
        {
            IQueryable<PostsVM> Posts = dbContext.PREGUNTA
                                                 .Select(p => new PostsVM
                                                 {
                                                     ID_PREGUNTA = p.ID_PREGUNTA,
                                                     CARRERA = p.CARRERA,
                                                     TEMA = p.TEMA,
                                                     PREGUNTA1 = p.PREGUNTA1,
                                                     RESUELTO = p.RESUELTO.Value,
                                                     FECHA = p.FECHA.Value,
                                                     NUM_RESP = p.NUM_RESP.Value,
                                                     USERNAME = p.USERNAME,
                                                 }).AsQueryable();

            return View(Posts);
        }

        public PartialViewResult GetComments(int postId)
        {
            IQueryable<CommentsVM> comments = dbContext.RESPUESTA.Where(c => c.PREGUNTA.ID_PREGUNTA == postId)
                                                       .Select(c => new CommentsVM
                                                       {
                                                           ID_RESPUESTA = c.ID_RESPUESTA,
                                                           RESP = c.RESP,
                                                           C_DISLIKE = c.C_DISLIKE.Value,
                                                           TIPO = c.TIPO.Value,
                                                           FECHA = c.FECHA.Value,
                                                           Users = new UserVM
                                                           {
                                                               USERNAME = c.USUARIO.USERNAME,
                                                               NOMBRE = c.USUARIO.NOMBRE,
                                                               APELLIDO = c.USUARIO.APELLIDO,
                                                               DNI = c.USUARIO.DNI,
                                                               PAIS = c.USUARIO.PAIS,
                                                               EMAIL = c.USUARIO.EMAIL,
                                                               PASSWORD = c.USUARIO.PASSWORD
                                                           }
                                                       }).AsQueryable();

            return PartialView("~/Views/Shared/_MyComments.cshtml", comments);
        }

        [HttpPost]
        public ActionResult AddComment(CommentsVM comment, int postId)
        {
            //bool result = false;
            RESPUESTA commentEntity = null;
            string userId = (string)Session["USERNAME"];

            var user = dbContext.USUARIO.FirstOrDefault(u => u.USERNAME == userId);
            var post = dbContext.PREGUNTA.FirstOrDefault(p => p.ID_PREGUNTA == postId);

            if (comment != null)
            {

                commentEntity = new Models.RESPUESTA
                {
                    RESP = comment.RESP,
                    C_LIKE = 0,      // comment.C_LIKE,
                    C_DISLIKE = 0,    //  comment.C_DISLIKE,
                    TIPO = false,         //comment.TIPO,
                    FECHA = comment.FECHA,
                };


                if (user != null && post != null)
                {
                    post.RESPUESTA.Add(commentEntity);
                    user.RESPUESTA.Add(commentEntity);
                    dbContext.SaveChanges();
                    /*
                    try
                    {
                        post.RESPUESTA.Add(commentEntity);
                        user.RESPUESTA.Add(commentEntity);
                        dbContext.SaveChanges();
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                            }
                        }
                    }
                    */

                    //result = true;
                }
            }

            return RedirectToAction("GetComments", "Comments", new { postId });
        }
        // ------------------------------------------------------
        /*
        [HttpGet]
        public PartialViewResult GetSubComments(int ComID)
        {
            IQueryable<SubCommentsVM> subComments = dbContext.SubComments.Where(sc => sc.Comment.ComID == ComID)
                                                              .Select(sc => new SubCommentsVM
                                                              {
                                                                  SubComID = sc.SubComID,
                                                                  CommentMsg = sc.CommentMsg,
                                                                  CommentedDate = sc.CommentedDate.Value,
                                                                  User = new UserVM
                                                                  {
                                                                      UserID = sc.User.UserID,
                                                                      Username = sc.User.Username,
                                                                      imageProfile = sc.User.imageProfile
                                                                  }
                                                              }).AsQueryable();

            return PartialView("~/Views/Shared/_MySubComments.cshtml", subComments);
        }

        [HttpPost]
        public ActionResult AddSubComment(SubCommentsVM subComment, int ComID)
        {
            SubComment subCommentEntity = null;
            int userId = (int)Session["UserID"];

            var user = dbContext.Users.FirstOrDefault(u => u.UserID == userId);
            var comment = dbContext.Comments.FirstOrDefault(p => p.ComID == ComID);

            if (subComment != null)
            {

                subCommentEntity = new EDMX.SubComment
                {
                    CommentMsg = subComment.CommentMsg,
                    CommentedDate = subComment.CommentedDate,
                };


                if (user != null && comment != null)
                {
                    comment.SubComments.Add(subCommentEntity);
                    user.SubComments.Add(subCommentEntity);

                    dbContext.SaveChanges();
                    //result = true;
                }
            }

            return RedirectToAction("GetSubComments", "Comments", new { ComID = ComID });
        }
        */
    }
}