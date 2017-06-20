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
        [HttpGet]
        public List<Comment> Get()
        {
            return _comment.AllComments();
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public Comment Get(int id)
        {
            return _comment.GetComment(id);
        }

        // POST: api/Comment
        [HttpPost]
        public IActionResult Post([FromBody]Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }
            else if (comment.Id == 0)
            {
                _comment.AddComment(comment);
                return Ok();
            }
            else
            {
                _comment.UpdateComment(comment);
                return Ok();
            }
        }

        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _comment.DeleteComment(id);
        }
    }
}
