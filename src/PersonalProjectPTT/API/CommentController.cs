using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalProjectPTT.Interfaces;
using PersonalProjectPTT.Models;

namespace PersonalProjectPTT.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        ICommentService _comment;

        public CommentController(ICommentService comment)
        {
            _comment = comment;
        }

        // GET: api/Comment
        //[HttpGet]
        //public List<Comment> Get()
        //{
        //    return _comment.AllComments();
        //}

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public List<Comment> Get(int id)
        {
            //return _comment.GetComment(id);
            return _comment.AllComments(id);

        }

        // POST: api/Comment
        [HttpPost]
        public IActionResult Post([FromBody]CommentRequest rqst)
        {
            if (rqst == null)
            {
                return BadRequest();
            }
            else if (rqst != null && rqst.comment.Id == 0)
            {
                rqst.comment.CreateDate = DateTime.Now;

                _comment.AddComment(rqst.taskId, rqst.comment);
                return Ok();


            }
            else if (rqst != null)
            {
                _comment.UpdateComment(rqst.comment);
                return Ok();
            }

            return BadRequest(); //in case everything has failed
        }


    }

    public class CommentRequest
    {
        public int taskId { get; set; }
        public Comment comment { get; set; }
    }
}
