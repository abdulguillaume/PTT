using PersonalProjectPTT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProjectPTT.Models;


using Microsoft.EntityFrameworkCore;

namespace PersonalProjectPTT.Services
{
    public class CommentService : ICommentService
    {
        private IGenericRepository _repo;
        private ITaskService _ts;

        public CommentService(IGenericRepository repo, ITaskService ts)
        {
            _repo = repo;
            _ts = ts;
        }

        public void AddComment(Comment comment)
        {
            _repo.Add(comment);
        }

        public void AddComment(int taskId, Comment comment)
        {
            ATask task = _ts.GetTask(taskId);

            comment.LinkedTask = task;

            _repo.Add(comment);
        }

        public List<Comment> AllComments()
        {
            List<Comment> comments = (from c in _repo.Query<Comment>()
                                      .Include(t=>t.LinkedTask)
                                    select c
                           ).ToList();
            return comments;
        }

        public List<Comment> AllComments(int taskId)
        {
            List<Comment> comments = (from c in _repo.Query<Comment>()
                                      .Include(t => t.LinkedTask)
                                      where c.LinkedTask.Id == taskId
                                      select c
                           ).ToList();
            return comments;
        }

        public void DeleteComment(int id)
        {
            Comment toDelete = GetComment(id);
            _repo.Delete(toDelete);
        }

        public Comment GetComment(int id)
        {
            Comment comment = (from c in _repo.Query<Comment>()
                             where c.Id == id
                             select c
                          ).FirstOrDefault();
            return comment;
        }

        public void UpdateComment(Comment comment)
        {
            _repo.Update(comment);
        }
    }
}
