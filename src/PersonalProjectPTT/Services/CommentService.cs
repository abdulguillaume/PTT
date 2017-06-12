using PersonalProjectPTT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProjectPTT.Models;

namespace PersonalProjectPTT.Services
{
    public class CommentService : ICommentService
    {
        private IGenericRepository _repo;

        public CommentService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public void AddComment(Comment comment)
        {
            _repo.Add(comment);
        }

        public List<Comment> AllComments()
        {
            List<Comment> comments = (from c in _repo.Query<Comment>()
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
