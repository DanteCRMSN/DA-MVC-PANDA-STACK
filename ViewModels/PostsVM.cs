using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PANDA_MVC_V5.ViewModels
{
    public class PostsVM
    {
        /*
        public int PostID { get; set; }
        public string Message { get; set; }
        public DateTime PostedDate { get; set; }
        */
        public int ID_PREGUNTA { get; set; }
        public string CARRERA { get; set; }
        public string TEMA { get; set; }
        public string PREGUNTA1 { get; set; }
        public bool RESUELTO { get; set; }
        public DateTime FECHA { get; set; }
        public int NUM_RESP { get; set; }
        public string USERNAME { get; set; }
    }

    public class CommentsVM
    {
        /*
        public int ComID { get; set; }
        public string CommentMsg { get; set; }
        public DateTime CommentedDate { get; set; }
        public PostsVM Posts { get; set; }
        public UserVM Users { get; set; }
        */

        public int ID_RESPUESTA { get; set; }
        public string RESP { get; set; }
        public int C_LIKE { get; set; }
        public int C_DISLIKE { get; set; }
        public bool TIPO { get; set; }
        public DateTime FECHA { get; set; }
        //vm
        public UserVM Users { get; set; }
        public PostsVM Posts { get; set; }
    }

    public class UserVM
    {
        /*
        public int UserID { get; set; }
        public string Username { get; set; }
        public string imageProfile { get; set; }
        */
        public string USERNAME { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string DNI { get; set; }
        public string PAIS { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
    }

    /*
    public class SubCommentsVM
    {
        public int SubComID { get; set; }
        public string CommentMsg { get; set; }
        public DateTime CommentedDate { get; set; }
        public CommentsVM Comment { get; set; }
        public UserVM User { get; set; }
    }
    */

}